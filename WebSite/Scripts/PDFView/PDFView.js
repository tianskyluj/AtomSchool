$(function () {
    $('#content_edit').wysihtml5({
        "stylesheets": ["/templates/social/assets/js/bootstrap-wysihtml5/lib/css/wysiwyg-color.css"]
    });

    $('#sel_receiveUser').multiselect({
        includeSelectAllOption: true,
        enableFiltering: true,
        buttonWidth: '745px',
        buttonText: function (options, select) {
            if (options.length == 0) {
                return '请选择收件人 <b class="caret"></b>';
            }
            else if (options.length > 5) {
                return options.length + ' 位收件人被选中  <b class="caret"></b>';
            }
            else {
                var selected = '';
                options.each(function () {
                    selected += $(this).text() + ', ';
                });
                return selected.substr(0, selected.length - 2) + ' <b class="caret"></b>';
            }
        }
    });

    // 发送内部邮件
    $('#btn_sendEmail').click(function () {
        if ($('#title_edit').val().trim() == "") {
            showError('请输入邮件标题');
            return false;
        }
        if ($('#sel_receiveUser').val() == null) {
            showError('请选择收件人');
            return false;
        }
        var attach = '';
        $('.qq-upload-delete').each(function () {
            attach = attach + $(this).attr('id') + ',';
        });

        $.post(
                '/Email/SaveEmail',                                               // 修改表格名称
                {
                "Title": $('#title_edit').val().trim(),
                "Content": $('#content_edit').val(),
                "IsRead": false,
                "IsDeleteFromOutBox": false,
                "receiveUsers": getMulitiSelectValue($('#sel_receiveUser')),
                "uploadString": attach
            },
                function (result) { if (result == "1") { redirect("/Email/Sentbox"); showSuccess("操作成功"); } else { showError("出错了，请稍后再试或者联系系统管理员") } }
        );
    });

    // 清空表单
    $('#btn_reset').click(function () {
        $('#form_newEmail')[0].reset();
        initMulitiSelect($('#sel_receiveUser'));
        setMulitiSelectTitle($('#sel_receiveUser'), '请选择收件人 ');
    });

    /// 这里控制附件上传

    $('#jquery-wrapped-fine-uploader').fineUploader({
        request: {
            endpoint: '/UploadFile/Upload'
        },
        callbacks: {
            onComplete: function (id, fileName, responseJSON) {
                $('.qq-upload-delete').each(function () { $(this).html('删除'); });
                $('.qq-upload-list').children("li:last-child").children('.qq-upload-delete').attr('id', responseJSON['ID'])
                $('.qq-upload-delete').click(function () {
                    var id = $(this).attr('id');
                    $(this).parent().remove(); 
                    $.post(
                            '/UploadFile/Delete',                                               // 修改表格名称
                            {
                            "ID": id
                        },
                            function (result) { if (result == "1") {  } else { showError("出错了，请稍后再试或者联系系统管理员") } }
                    );
                });
            }
        }
    });

    $('.qq-upload-button').children().eq(0).html("上传附件");
    $('.qq-drop-processing').children().eq(0).html("拖拽文件至此上传");

});
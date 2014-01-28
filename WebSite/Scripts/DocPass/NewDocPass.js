$(function () {
    $('#sel_receiveUser').multiselect({
        includeSelectAllOption: true,
        enableFiltering: true,
        buttonWidth: '231px',
        buttonText: function (options, select) {
            if (options.length == 0) {
                return '请选择指定传阅用户 <b class="caret"></b>';
            }
            else if (options.length > 5) {
                return options.length + ' 位用户被选中  <b class="caret"></b>';
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
    $('#btn_sendPass').click(function () {
        if ($('#title_edit').val().trim() == "") {
            showError('请输入传阅主题');
            return false;
        }
        if ($('#sel_receiveUser').val() == null) {
            showError('请选择传阅用户');
            return false;
        }
        if ($('.qq-upload-delete').length == 0) {
            showError('请上传待传阅的pdf文件');
            return false;
        }

        var attach = '';
        $('.qq-upload-delete').each(function () {
            attach = attach + $(this).attr('id') + ',';
        });
        $.post(
                '/DocPass/SavePass',                                               // 修改表格名称
                {
                "Title": $('#title_edit').val().trim(),
                "Attachment": "",
                "receiveUsers": getMulitiSelectValue($('#sel_receiveUser')),
                "uploadString": attach
            },
                function (result) {
                    if (result.indexOf("您没有权限进行该操作") >= 0) {
                        showError("您没有权限进行该操作")
                        return false;
                    }
                    if (result == "1") { showSuccess("操作成功"); } else { showError("出错了，请稍后再试或者联系系统管理员") } 
                }
        );
    });

    // 清空表单
    $('#btn_reset').click(function () {
        $('#form_newTask')[0].reset();
        initMulitiSelect($('#sel_receiveUser'));
        setMulitiSelectTitle($('#sel_receiveUser'), '请选择任务接收人 ');
    });

    /// 这里控制附件上传

    $('#jquery-wrapped-fine-uploader').fineUploader({
        request: {
            endpoint: '/UploadFile/Upload'
        },
        validation: {
            allowedExtensions: ['pdf'],
            sizeLimit: 3000 * 1024,
            itemLimit: 1
        },
        callbacks: {
//            onSubmit: function () {
//                if ($('.qq-upload-delete').length > 0) {
//                    alert('同时只能传阅一份文件,请再添加另一次传阅');
//                    return false;
//                    $('#jquery-wrapped-fine-uploader').cancelAll();
//                }
//            },

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
                            function (result) { if (result == "1") { } else { showError("出错了，请稍后再试或者联系系统管理员") } }
                    );
                });
            }
        }
    });

    $('.qq-upload-button').children().eq(0).html("上传附件");
    $('.qq-drop-processing').children().eq(0).html("拖拽文件至此上传");
});
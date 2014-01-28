$(function () {


    $('#task_edit').wysihtml5({
        "stylesheets": ["/templates/social/assets/js/bootstrap-wysihtml5/lib/css/wysiwyg-color.css"]
    });

    $('#sel_receiveUser').multiselect({
        includeSelectAllOption: true,
        enableFiltering: true,
        buttonWidth: '231px',
        buttonText: function (options, select) {
            if (options.length == 0) {
                return '请选择任务接收人 <b class="caret"></b>';
            }
            else if (options.length > 5) {
                return options.length + ' 位任务接收人被选中  <b class="caret"></b>';
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

    $('#datetimepicker_deadline').datetimepicker();

    // 发送内部邮件
    $('#btn_sendTask').click(function () {
        if ($('#title_edit').val().trim() == "") {
            showError('请输入任务名称');
            return false;
        }
        if ($('#sel_receiveUser').val() == null) {
            showError('请选择任务接收人');
            return false;
        }
        if ($('#datetimepicker_deadline input').val().trim() == '') {
            showError('请选择任务时限');
            return false;
        }
        $.post(
                '/Task/SaveTask',                                               // 修改表格名称
                {
                "Title": $('#title_edit').val().trim(),
                "Content": $('#Content').val(),
                "deadline": $('#datetimepicker_deadline input').val(),
                "TaskLevel": $('#sel_taskLevel').val(),
                "receiveUsers": getMulitiSelectValue($('#sel_receiveUser'))
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
});
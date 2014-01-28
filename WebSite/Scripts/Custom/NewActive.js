$(function () {
    $('#maintainTime_edit').datetimepicker();
    // 发送内部邮件
    $('#btn_save').click(function () {
        if ($('#sel_maintainMethod').val() == '0') {
            showError('请选择维护方式');
            return false;
        }
        if ($('#sel_maintainType').val() == '0') {
            showError('请选择维护类型');
            return false;
        }
        if ($('#sel_custom').val() == '0') {
            showError('请选择维护客户');
            return false;
        }
        if ($('#maintainTime_edit input').val().trim() == '') {
            showError('选择维系时间');
            return false;
        }
        if ($('#result_edit').val().trim() == '') {
            showError('填写维系结果');
            return false;
        }
        $.post(
                '/Custom/SaveMaintain',                                               // 修改表格名称
                {
                "MaintainMethod": $('#sel_maintainMethod').val(),
                "MaintainType": $('#sel_maintainType').val(),
                "Custom":$('#sel_custom').val(),
                "MaintainTime": $('#maintainTime_edit input').val().trim(),
                "Result": $('#result_edit').val().trim()
            },
                function (result) {
                    if (result.indexOf("您没有权限进行该操作") >= 0) {
                        showError("您没有权限进行该操作")
                        return false;
                    }
                    if (result == "1") { showSuccess("操作成功"); } else if (result == '-1') { showError("没有人担任所选角色") } else { showError("出错了，请稍后再试或者联系系统管理员") } 
                }
        );
    });

    // 清空表单
    $('#btn_reset').click(function () {
        $('#form_newCustom')[0].reset();
        $('#sel_maintainMethod').val('0');
        $('#sel_maintainType').val('0');
        $('#sel_custom').val('0');
    });
});
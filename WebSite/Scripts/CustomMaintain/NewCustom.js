$(function () {

    $('#birthday_edit').datetimepicker();

    // 发送内部邮件
    $('#btn_save').click(function () {
        if ($('#sel_customType').val() == '0') {
            showError('请选择申请类型');
            return false;
        }
        if ($('#customName_edit').val().trim() == '') {
            showError('请填写用户姓名');
            return false;
        }
        if ($('#telphone_edit').val().trim() == '') {
            showError('请填写用户联系方式');
            return false;
        }
        if ($('#birthday_edit input').val().trim() == '') {
            showError('请选择用户生日');
            return false;
        }
        $.post(
                '/Custom/SaveCustom',                                               // 修改表格名称
                {
                "Name": $('#customName_edit').val().trim(),
                "Telphone": $('#telphone_edit').val().trim(),
                "Birthday": $('#birthday_edit input').val().trim(),
                "CustomType": $('#sel_customType').val()
            },
                function (result) { if (result == "1") { showSuccess("操作成功"); } else if (result == '-1') { showError("没有人担任所选角色") } else { showError("出错了，请稍后再试或者联系系统管理员") } }
        );
    });

    // 清空表单
    $('#btn_reset').click(function () {
        $('#form_newCustom')[0].reset();
        $('#sel_customType').val('0');
    });
});
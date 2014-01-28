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
                "ID":$('#customID').val(),
                "Name": $('#customName_edit').val().trim(),
                "Telphone": $('#telphone_edit').val().trim(),
                "Birthday": $('#birthday_edit input').val().trim(),
                "CustomType": $('#sel_customType').val()
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

    if ($('#customID').val() != '') {
        $.post(
            '/Custom/Update',                                               // 修改表格名称
            {
            "ID": $('#customID').val()
        },
            function (result) {
                if (result.indexOf("您没有权限进行该操作") >= 0) {
                    showError("您没有权限进行该操作")
                    return false;
                }
                var entity = eval("(" + result + ")");
                $('#sel_customType').val(entity.CustomType.ID);
                $('#customName_edit').val(entity.Name);
                $('#telphone_edit').val(entity.Telphone);

                var date = new Date(parseInt(entity.Birthday.substr(6)));

                var d = new Date(date.format("yyyy-mm-dd"))
                $('#birthday_edit').datetimepicker("setDate", d);
                $('#remark').val(entity.Remark);
            }
        );
    }

    // 清空表单
    $('#btn_reset').click(function () {
        $('#form_newCustom')[0].reset();
        $('#sel_customType').val('0');
    });
});
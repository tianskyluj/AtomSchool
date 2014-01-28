$(function () {
    function profileViewModel() {
        this.telephone = ko.observable($('#telephone_edit').val());
        this.email = ko.observable($('#email_edit').val());
        this.QQ = ko.observable($('#QQ_edit').val());

        this.oldPassword = ko.observable('');
        this.newPassword = ko.observable('');
        this.newPasswordAgain = ko.observable('');

        // 点击更改按钮
        this.profileChange = function () {
            $.post(
                    '/Account/UpdateProfile',
                    { "id": $('.userId').val(), "Phone": this.telephone(), "Email": this.email(), "QQ": this.QQ() },
                    function (result) { if (result == "1") { showSuccess("操作成功"); } else { showError("修改个人资料出错，请稍后再试或者联系系统管理员") } }
            );
        };

        this.UploadAvatar = function () {
            if ($('.fileupload-preview').children().attr('src') == undefined) {
                showError("请先上传图片");
                return false;
            }
            $.post(
                    '/Account/UploadAvatar',
                    { "avatar": $('.fileupload-preview').children().attr('src') },
                    function (result) { if (result == "1") { showSuccess("操作成功"); } else { showError("修改头像，请稍后再试或者联系系统管理员") } }
            );
        }

        this.UpdatePassword = function () {
            if (this.oldPassword().trim() == '') {
                showError("请输入旧密码");
                return false;
            }
            if (this.newPassword() == '') {
                showError("请输入新密码");
                return false;
            }
            if (this.newPasswordAgain() == '') {
                showError("请再次输入新密码");
                return false;
            }
            if (this.newPassword() != this.newPasswordAgain()) {
                showError("两次输入新密码不一致");
                return false;
            }
            $.post(
                    '/Account/UpdatePassword',
                    { "oldPassword": this.oldPassword(), "newPassword": this.newPassword(), "newPasswordAgain": this.newPasswordAgain() },
                    function (result) { if (result == "1") { showSuccess("操作成功"); } else { showError(result) } }
            );
        }
    }

    // 注册用户模型
    ko.cleanNode(document.body);
    ko.applyBindings(new profileViewModel(), document.body);
});
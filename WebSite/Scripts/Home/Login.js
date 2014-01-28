$(function () {
    function userViewModel() {
        this.userName = ko.observable("");
        this.passWord = ko.observable("");

        // 点击登录按钮
        this.login = function () {
            if (this.userName().trim() == "") {
                showError("请输入用户名……");
                return false;
            }
            if (this.passWord().trim() == "") {
                showError("请输入密码……");
                return false;
            }
            $.post(
                    '/Home/DoLogin',
                    { "Account": this.userName(), "passWord": this.passWord() },
                    function (result) { if (result == "1") { window.location.href = "/Home/Index"; } else { showError("用户名密码不正确") } }
            );
        };
    }

    // 注册用户模型
    ko.applyBindings(new userViewModel());
});
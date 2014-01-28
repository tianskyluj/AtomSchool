$(function () {
    $('.sign').click(function () {
        $.post(
                    '/Home/Registration',
                    {
                        "userId": $('.userId').val()
                    },
                    function (result) { if (result == "1") { $('.sign').html('下班'); showSuccess("操作成功"); } else { showError("操作出错，请稍后再试或者联系系统管理员") } }
            );
    });

});




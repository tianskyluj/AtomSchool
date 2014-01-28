
$(function () {
    $('#rightIsExpend').click(function () {
        var parentModel = $('.rightTree').find('li:has(ul)').addClass('parent_li').attr('role', 'treeitem').find(' > span').attr('title', 'Collapse this branch');
        parentModel.each(function () {
            var children = $(this).parent('li.parent_li').find(' > ul > li');
            if (children.is(':visible')) {
                children.hide('fast');
                $(this).attr('title', 'Expand this branch').find(' > i').addClass('icon-plus-sign').removeClass('icon-minus-sign');
            }
            else {
                children.show('fast');
                $(this).attr('title', 'Collapse this branch').find(' > i').addClass('icon-minus-sign').removeClass('icon-plus-sign');
            }
            //e.stopPropagation();
        });
        if ($('#rightIsExpend').html() == "展开")
            $('#rightIsExpend').html("收起");
        else
            $('#rightIsExpend').html("展开")
    });

    // 行权限全选
    $('.selectAll').click(function () {
        var $checkbox = $(this).parent().parent().find('.checkbox');
        if ($(this).is(':checked')) {
            $checkbox.children('input').prop('checked', true);
        }
        else {
            $checkbox.children('input').prop('checked', false);
        }
    });

    // 全选所有权限
    $('#selectAllRights').click(function () {
        $('.rightTree').find('.checkbox').children('input').prop('checked', true);
    });

    // 重置所有权限
    $('#initAllRights').click(function () {
        $('.rightTree').find('.checkbox').children('input').prop('checked', false);
    });

    // 保存权限
    $('#saveRights').click(function () {

        var rightRow = $('.rightRow')

        rightRow.each(function () {
            //            alert($(this).find('#pageModelID').val());
            var rightsSTR = '';
            $(this).find('.rightCheckBox').each(function () {
                if ($(this).children('input').is(':checked')) {
                    rightsSTR += $(this).children('input').val() + ',';
                }
            });

            $.post(
                '/Rights/SaveRights',
                {
                    "modelID": $(this).find('#pageModelID').val(),
                    "rightsSTR": rightsSTR,
                    "roleID": $('#sel_roleRights').val()
                },
                function (result) {

                }
            );
            redirect('/System/Index'); showSuccess("操作成功");
        });
    });

    GetRghtWithRoleID($('#sel_roleRights').val());

    $('#sel_roleRights').change(function () {
        $('.rightTree').find('.checkbox').children('input').prop('checked', false);
        GetRghtWithRoleID($('#sel_roleRights').val());
    });
});

// 根据用户所选角色ID显示页面权限
function GetRghtWithRoleID(roleID) {
    $.post(
        '/Rights/GetRghtWithRoleID',
        {
            "ID": roleID
        },
        function (result) {
            var entity = eval("(" + result + ")");
            for (i = 0; i < entity.length; i++) {
                $("input[value=" + entity[i].SystemModel.ID + "]").parent().find("input[value=" + entity[i].Rights.ID + "]").prop('checked', true);
            }
        }
    );
}

$(function () {
    function globalViewModel() {
        this.companyName = ko.observable($('#companyName_edit').val());

        this.isProvince = ko.observable($('#isProvince_edit').val() == 'True');

        this.isCity = ko.observable($('#isCity_edit').val() == 'True');

        this.isRegion = ko.observable($('#isRegion_edit').val() == 'True');

        this.isDepartment = ko.observable($('#isDepartment_edit').val() == 'True');

        this.modelName = ko.observable($('#modelName_edit').val());
        this.modelUrl = ko.observable($('#modelUrl_edit').val());
        //this.modelIsEnable = ko.observable($('#modelIsEnable_edit').val() == 'True');

        // 点击更改按钮
        this.change = function () {
            if (this.companyName().trim() == "") {
                showError("请输入公司名称……");
                return false;
            }
            $.post(
                    '/System/UpdateGolbal',
                    {
                        "id": '0',
                        "companyName": this.companyName(),
                        "isProvince": this.isProvince(),
                        "isCity": this.isCity(),
                        "isRegion": this.isRegion(),
                        "isDepartment": this.isDepartment()
                    },
                    function (result) { if (result == "1") { showSuccess("操作成功"); } else { showError("修改全局设置出错，请稍后再试或者联系系统管理员") } }
            );
        };

        // 模块树结构展开收起
        this.isExpand = function () {
            var parentModel = $('.modelTree').find('li:has(ul)').addClass('parent_li').attr('role', 'treeitem').find(' > span').attr('title', 'Collapse this branch');
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
            if ($('#btn_isExpand').html() == "展开")
                $('#btn_isExpand').html("收起");
            else
                $('#btn_isExpand').html("展开")
        }

        // 保存模块更改
        this.saveModel = function () {
            if ($('#modelName_edit').val().trim() == "") {
                showError("请输入模块名称……");
                return false;
            }
            $.post(
                    '/SystemModel/SaveSystemModel',
                    {
                        "name": $('#modelName_edit').val().trim(),
                        "url": $('#modelUrl_edit').val().trim(),
                        "parentId": $('#parentModel').val(),
                        "isEnabled": $("#modelIsEnable_edit").prop("checked")
                    },
                    function (result) { if (result == "1") { redirect('/System/Index'); alert("操作成功"); } else { showError("操作出错，请稍后再试或者联系系统管理员") } }
            );
            $("#addAndUpdateModel").modal("hide");
        }

        // 添加系统模块
        this.addModel = function () {
            $('#modelName_edit').val('');
            $("#modelAddAndUpdateTitle").html("添加");
            $("#addAndUpdateModel").modal("show");
        }



        // 父节点下拉列表变化时兄弟节点下拉列表做相应变化
        $('#parentModel').change(function () {
            parentModelChanged();
        });
    }

    parentModelChanged();

    // 注册模型
    ko.cleanNode(document.body);
    ko.applyBindings(new globalViewModel(), document.body);

    $(".deleteModel").bind({
        click: function () {
            if (confirm('将删除该模块和包含的子模块,确定删除吗')) {
                $.post(
                '/SystemModel/DeleteSystemModel',
                {
                    "name": $(this).siblings('span').children('span').html()
                },
                function (result) { if (result == "1") { redirect('/System/Index'); alert("操作成功"); } else { showError("操作出错，请稍后再试或者联系系统管理员") } }
            );
            }
        }
    });

    $(".modifyModel").bind({
        click: function () {
            $("#modelAddAndUpdateTitle").html("修改");
            $.post(
                    '/SystemModel/UpdateSystemModel',
                    {
                        "name": $(this).siblings('span').children('span').html()
                    },
                    function (result) {
                        var entity = eval("(" + result + ")");
                        $('#modelName_edit').val(entity.Name);
                        $('#modelUrl_edit').val(entity.Url);
                        $('#parentModel').val(entity.ParentId);
                        if (entity.IsEnabled == true) {
                            $('#modelIsEnable_edit').prop('checked', true);
                        }
                        else {
                            $('#modelIsEnable_edit').prop("checked", false);
                        }
                    }
            );
            $("#addAndUpdateModel").modal("show");
        }
    });

});

function parentModelChanged() {
    var sibling = $('.opt_siblingModel');
    var parentId = $('#parentModel').val();
    var hideSibling = $('.opt_siblingModel[parentid!="' + parentId + '"]');

    sibling.each(function () {
        if ($(this).parent().is("span")) {
            $(this).unwrap();
        }
    });

    hideSibling.each(function () {
        $(this).wrap("<span style='display:none'></span>");
    });
}

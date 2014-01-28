
/* Set the defaults for DataTables initialisation */
$.extend(true, $.fn.dataTable.defaults, {
    "sDom": "<'row-fluid'<'span6'l><'span6'f>r>t<'row-fluid'<'span6'i><'span6'p>>",
    "sPaginationType": "bootstrap",
    "oLanguage": {
        "sLengthMenu": "_MENU_ records per page"
    }
});


/* Default class modification */
$.extend($.fn.dataTableExt.oStdClasses, {
    "sWrapper": "dataTables_wrapper form-inline"
});


/* API method to get paging information */
$.fn.dataTableExt.oApi.fnPagingInfo = function (oSettings) {
    return {
        "iStart": oSettings._iDisplayStart,
        "iEnd": oSettings.fnDisplayEnd(),
        "iLength": oSettings._iDisplayLength,
        "iTotal": oSettings.fnRecordsTotal(),
        "iFilteredTotal": oSettings.fnRecordsDisplay(),
        "iPage": oSettings._iDisplayLength === -1 ?
			0 : Math.ceil(oSettings._iDisplayStart / oSettings._iDisplayLength),
        "iTotalPages": oSettings._iDisplayLength === -1 ?
			0 : Math.ceil(oSettings.fnRecordsDisplay() / oSettings._iDisplayLength)
    };
};


/* Bootstrap style pagination control */
$.extend($.fn.dataTableExt.oPagination, {
    "bootstrap": {
        "fnInit": function (oSettings, nPaging, fnDraw) {
            var oLang = oSettings.oLanguage.oPaginate;
            var fnClickHandler = function (e) {
                e.preventDefault();
                if (oSettings.oApi._fnPageChange(oSettings, e.data.action)) {
                    fnDraw(oSettings);
                }
            };

            $(nPaging).addClass('pagination').append(
				'<ul>' +
					'<li class="prev disabled"><a href="#">&larr; ' + oLang.sPrevious + '</a></li>' +
					'<li class="next disabled"><a href="#">' + oLang.sNext + ' &rarr; </a></li>' +
				'</ul>'
			);
            var els = $('a', nPaging);
            $(els[0]).bind('click.DT', { action: "previous" }, fnClickHandler);
            $(els[1]).bind('click.DT', { action: "next" }, fnClickHandler);
        },

        "fnUpdate": function (oSettings, fnDraw) {
            var iListLength = 5;
            var oPaging = oSettings.oInstance.fnPagingInfo();
            var an = oSettings.aanFeatures.p;
            var i, ien, j, sClass, iStart, iEnd, iHalf = Math.floor(iListLength / 2);

            if (oPaging.iTotalPages < iListLength) {
                iStart = 1;
                iEnd = oPaging.iTotalPages;
            }
            else if (oPaging.iPage <= iHalf) {
                iStart = 1;
                iEnd = iListLength;
            } else if (oPaging.iPage >= (oPaging.iTotalPages - iHalf)) {
                iStart = oPaging.iTotalPages - iListLength + 1;
                iEnd = oPaging.iTotalPages;
            } else {
                iStart = oPaging.iPage - iHalf + 1;
                iEnd = iStart + iListLength - 1;
            }

            for (i = 0, ien = an.length; i < ien; i++) {
                // Remove the middle elements
                $('li:gt(0)', an[i]).filter(':not(:last)').remove();

                // Add the new list items and their event handlers
                for (j = iStart; j <= iEnd; j++) {
                    sClass = (j == oPaging.iPage + 1) ? 'class="active"' : '';
                    $('<li ' + sClass + '><a href="#">' + j + '</a></li>')
						.insertBefore($('li:last', an[i])[0])
						.bind('click', function (e) {
						    e.preventDefault();
						    oSettings._iDisplayStart = (parseInt($('a', this).text(), 10) - 1) * oPaging.iLength;
						    fnDraw(oSettings);
						});
                }

                // Add / remove disabled classes from the static elements
                if (oPaging.iPage === 0) {
                    $('li:first', an[i]).addClass('disabled');
                } else {
                    $('li:first', an[i]).removeClass('disabled');
                }

                if (oPaging.iPage === oPaging.iTotalPages - 1 || oPaging.iTotalPages === 0) {
                    $('li:last', an[i]).addClass('disabled');
                } else {
                    $('li:last', an[i]).removeClass('disabled');
                }
            }
        }
    }
});


/*
* TableTools Bootstrap compatibility
* Required TableTools 2.1+
*/
if ($.fn.DataTable.TableTools) {
    // Set the classes that TableTools uses to something suitable for Bootstrap
    $.extend(true, $.fn.DataTable.TableTools.classes, {
        "container": "DTTT btn-group",
        "buttons": {
            "normal": "btn",
            "disabled": "disabled"
        },
        "collection": {
            "container": "DTTT_dropdown dropdown-menu",
            "buttons": {
                "normal": "",
                "disabled": "disabled"
            }
        },
        "print": {
            "info": "DTTT_print_info modal"
        },
        "select": {
            "row": "active"
        }
    });

    // Have the collection use a bootstrap compatible dropdown
    $.extend(true, $.fn.DataTable.TableTools.DEFAULTS.oTags, {
        "collection": {
            "container": "ul",
            "button": "li",
            "liner": "a"
        }
    });
}

/* Get the rows which are currently selected */
function fnGetSelected(oTableLocal) {
    return oTableLocal.$('tr.info');
}

$(function () {
    var oTable;

    /* Add a click handler to the rows - this could be used as a callback */
    $("#provinceListTable tbody").on('click', 'tr', function (e) {                  // 修改表格名称
        if ($(this).hasClass('info')) {
            $(this).removeClass('info').removeClass('text-success');                                     // 修改隐藏ID名称
        }
        else {
            oTable.$('tr.info').removeClass('info');
            $(this).addClass('info').addClass('text-success');
        }
    });

    /* Init the table */
    oTable = $('#provinceListTable').dataTable({                                    // 修改表格名称
        "sDom": "<'row-fluid'<'span6'l><'span6'f>r>t<'row-fluid'<'span6'i><'span6'p>>",
        "sPaginationType": "bootstrap",
        "oLanguage": {
            "sProcessing": "处理中...",
            "sLengthMenu": "显示 _MENU_ 项结果",
            "sZeroRecords": "没有匹配结果",
            "sInfo": "显示第 _START_ 至 _END_ 项结果，共 _TOTAL_ 项",
            "sInfoEmpty": "显示第 0 至 0 项结果，共 0 项",
            "sInfoFiltered": "(由 _MAX_ 项结果过滤)",
            "sInfoPostFix": "",
            "sSearch": "搜索:",
            "sUrl": "",
            "oPaginate": {
                "sFirst": "首页",
                "sPrevious": "上页",
                "sNext": "下页",
                "sLast": "末页"
            }
        },
        "aaSorting": [[1, "asc"]],
        "aoColumnDefs": [
	          { 'bSortable': false, 'aTargets': [0] }
	       ]
    });



    $('#provinceListTable .toggle-checkboxes').click(function () {              // 修改表格名称
        var $checkbox = $("#provinceListTable").find('.checkbox');              // 修改表格名称
        if ($(this).is(':checked')) {
            $checkbox.prop('checked', true);
            $checkbox.each(function () { $(this).parent().parent('tr').addClass('info').addClass('text-success'); });
            $("#delete-row-province").removeClass("disabled");           // 修改删除按钮名称
            var checkedNum = $('#provinceListTable .checkbox').length
            $('#provinceCheckedNum').val(checkedNum); // 修改表格名称

        } else {
            $checkbox.prop('checked', false);
            $checkbox.each(function () { $(this).parent().parent('tr').removeClass('info').removeClass('text-success'); });
            $("#delete-row-province").addClass("disabled");                 // 修改删除按钮名称
            $('#provinceCheckedNum').val(0); // 修改表格名称
        }
    });

    $('#provinceListTable .checkbox').click(function () {                       // 修改表格名称
        var checkedNum = parseInt($('#provinceCheckedNum').val());              // 修改表格名称
        if ($(this).is(':checked')) {
            checkedNum++;
        }
        else {
            checkedNum--;
        }
        $('#provinceCheckedNum').val(checkedNum);                               // 修改表格名称
        if (checkedNum == 0) {
            $("#delete-row-province").addClass("disabled");                     // 修改表格名称
        }
        else {
            $("#delete-row-province").removeClass("disabled");                  // 修改表格名称
        }
    });

    $('#add-row-province').click(function () {                                   // 修改表格名称
        $('#provinceName_edit').val('');                                          // 修改表格名称   
        $('#provinceID').val('0');
        $("#provinceAddOrUpdateTitle").html("添加省份");                             // 修改表格名称
        $("#addAndUpdateProvince").modal("show");                                // 修改表格名称
    });

    $('#provinceListTable .modify').click(function () {                          // 修改表格名称
        $("#provinceAddOrUpdateTitle").html("修改省份");                           // 修改表格名称
        $('#provinceID').val($(this).attr('value'));
        $('#provinceIdd').html($(this).attr('value'));
        $.post(
                '/Province/UpdateProvince',
                {
                    "id": $(this).attr('value')
                },
                function (result) {
                    var entity = eval("(" + result + ")");
                    $('#provinceName_edit').val(entity.ProvinceName);
                }
            );
        $("#addAndUpdateProvince").modal("show");
    });

    // 删除记录
    $('#provinceListTable .delete').click(function () {                              // 修改表格名称
        if (confirm('确认删除该记录么')) {
            $.post(
                    '/Province/DeleteProvince',                                               // 修改表格名称
                    {
                    "id": $(this).attr('value')
                },
                    function (result) { if (result == "1") { redirect('/System/Index'); alert("操作成功"); } else { showError("出错了，请稍后再试或者联系系统管理员") } }
            );
        }
    });

    // 批量删除
    $('#delete-row-province').click(function () {
        var ifSelected = false;
        $("#provinceListTable .checkbox").each(function () {
            if ($(this).is(':checked')) {
                $.post(
                            '/Province/DeleteProvince',                                               // 修改表格名称
                            {
                            "id": $(this).attr('value')
                        }
                    );
                ifSelected = true;
                return true;
            }
        });
        if (!ifSelected)
            alert("进行批量操作请勾选至少一条记录！");
        redirect('/System/Index'); alert("操作成功");
        return ifSelected;
    });

    // 保存省份信息
    $('#saveProvince').click(function () {                                            // 修改表格名称
        if ($('#provinceName_edit').val().trim() == '') {
            showError('省份名称不能为空');
            return false;
        }
        $.post(
                '/Province/SaveProvince',                                               // 修改表格名称
                {
                "id": $('#provinceIdd').html(),
                "isEnabled": true,
                "provinceName": $('#provinceName_edit').val().trim()                // 修改表格名称
            },
                function (result) { if (result == "1") { $("#addAndUpdateProvince").modal("hide"); redirect('/System/Index'); alert("操作成功"); } else { showError("出错了，请稍后再试或者联系系统管理员") } }
        );
    });
});

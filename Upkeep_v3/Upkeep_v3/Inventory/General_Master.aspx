<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/UpkeepMaster.Master" CodeBehind="General_Master.aspx.cs" Inherits="Upkeep_v3.Inventory.General_Master2" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script src="<%= Page.ResolveClientUrl("~/vendors/jquery/dist/jquery.js") %>" type="text/javascript"></script>
    <style type="text/css">
        .modalBackground {
            background-color: grey;
            filter: alpha(opacity=90);
            opacity: 0.8;
        }

        .modalPopup {
            padding: 10px;
            width: 500px;
        }

        .highlight {
            background-color: #b4cae6;
        }
    </style>
    <script>
        $(document).ready(function () {
            $('#modal_Category').hide();
            $('#modal_SubCategory').hide();
            $('#modal_Item').hide();
            ShowCategory();
            ShowSubCategory();
            ShowItems();
            EditCategory();
            EditSubCategory();
            EditItem();
            SaveCategory();
            SaveSubCategory();
            SaveItem();
            CheckValidationCategory();
            CheckValidationSubCategory();
            CheckValidationItems();
            FetchDepartment();
            HightlightItemTable();
            PreesEntertoSave();
        });

        function PreesEntertoSave() {
            $('#txtCategory').keypress(function (e) {
                $("#lblCategory").text('');
                $("#lblCategory").hide();
                var key = e.which;
                if (key == 13)  // the enter key code
                {
                    $("[id*=editCategory_Click]").click();
                    return false;
                }
            });

            $('#txtSubCategory').keypress(function (e) {
                $("#lblSubCategory").text('');
                $("#lblSubCategory").hide();
                var key = e.which;
                if (key == 13)  // the enter key code
                {
                    $("[id*=editSubCategory_Click]").click();
                    return false;
                }
            });

            $('#txtItemDescription').keypress(function (e) {
                $("#lblItemDescription").text('');
                $("#lblItemDescription").hide();
                var key = e.which;
                if (key == 13)  // the enter key code
                {
                    $("[id*=editItem_Click]").click();
                    return false;
                }
            });
        }

        function HightlightItemTable() {
            $('#divItems').on('click', 'table tr', function () {
                var selected = $(this).hasClass("highlight");
                if (!selected)
                    $("#tblItems tr").removeClass("highlight");
                if (!selected)
                    $(this).addClass("highlight");
            });
        }

        function confirmSubCategoryAction() {
            var catename = '';
            $('#tblCategory > tbody  > tr').each(function (index, tr) {
                var selected = $(this).hasClass("highlight");
                if (selected) {
                    catename = $.trim($(this)[0].textContent);
                }
            });
            if (catename != "") {

                return false;
            }
            else {
                Swal.fire({
                    title: 'Please select Category...',
                    showClass: {
                        popup: 'animate__animated animate__fadeInDown'
                    },
                    hideClass: {
                        popup: 'animate__animated animate__fadeOutUp'
                    }
                })
                return false;
            }
        }

        function confirmItemAction() {
            var catename = '';
            var subcatename = '';
            $('#tblCategory > tbody  > tr').each(function (index, tr) {
                var selected = $(this).hasClass("highlight");
                if (selected) {
                    catename = $.trim($(this)[0].textContent);
                }
            });
            $('#tblSubCategory > tbody  > tr').each(function (index, tr) {
                var selected = $(this).hasClass("highlight");
                if (selected) {
                    subcatename = $.trim($(this)[0].textContent);
                }
            });

            if (catename != "" && subcatename != "") {
                return false;
            }
            else {
                Swal.fire({
                    title: 'Please select Category & SubCategory...',
                    showClass: {
                        popup: 'animate__animated animate__fadeInDown'
                    },
                    hideClass: {
                        popup: 'animate__animated animate__fadeOutUp'
                    }
                })
                return false;
            }
        }

        function FetchDepartment() {
            var mySelect = $('#ddl_Department');
            var item = '';
            var dataString = {
                'item': item,
            };
            var param = JSON.stringify(dataString);
            $.ajax({
                type: 'POST',
                url: 'General_Master2.aspx/FetchDepartment',
                data: param,
                contentType: 'application/json; charset=utf-8',
                datatype: 'json',
                success: function (response) {
                    if (response.d) {
                        $.each(response.d, function (val, text) {
                            mySelect.append($('<option></option>').val(val).html(text));
                        });
                    }
                },
                error: function (xhr, status, error) {
                }
            });
            return false;
        }

        function CheckValidationCategory() {
            $("#txtCategory").keyup(function (e) {
                $("#lblCategory").text('');
                $("#lblCategory").hide();
            });
        }

        function CheckValidationSubCategory() {
            $("#txtSubCategory").keyup(function (e) {
                $("#lblSubCategory").text('');
                $("#lblSubCategory").hide();
            });
        }

        function CheckValidationItems() {
            $("#txtOpening").keyup(function (e) {
                $("#lblOpening").text('');
                $("#lblOpening").hide();
            });
            $("#txtOptimun").keyup(function (e) {
                $("#lblOptimun").text('');
                $("#lblOptimun").hide();
            });
            $("#txtReorder").keyup(function (e) {
                $("#lblReorder").text('');
                $("#lblReorder").hide();
            });
            $("#txtBase").keyup(function (e) {
                $("#lblBase").text('');
                $("#lblBase").hide();
            });
            $("#txtCostRate").keyup(function (e) {
                $("#lblCostRate").text('');
                $("#lblCostRate").hide();
            });
            $("#txtItemDescription").keyup(function (e) {
                $("#lblItemDescription").text('');
                $("#lblItemDescription").hide();
            });

            $('#ddl_Department').change(function () {
                $("#lblddl_Department").text('');
                $("#lblddl_Department").hide();
            });
        }

        function SaveCategory() {
            $("[id*=btnCategory]").click(function () {
                $('#modal_Category').modal('toggle');
                $("#editCategoryModalLabel").text('Save Category');
                $("#txtCategory").val('');
                $("#lblCategory").text('');
                $("#hdn_Category").val('save');
                return false;
            });
        }

        function SaveSubCategory() {
            $("[id*=btnSubCategory]").click(function () {
                var catename = '';
                $('#tblCategory > tbody  > tr').each(function (index, tr) {
                    var selected = $(this).hasClass("highlight");
                    if (selected) {
                        catename = $.trim($(this)[0].textContent);
                    }
                });
                if (catename == "") {
                    document.getElementById("m_sweetalert_demo_3_1").click();
                    $("#swal2-title").text('Please select Category ..!');
                    $("#swal2-content").hide();
                }
                else {
                    $('#modal_SubCategory').modal('toggle');
                    $("#editSubCategoryModalLabel").text('Save Sub Category');
                    $("#txtSubCategory").val('');
                    $("#lblSubCategoryName").text(catename);
                    $("#lblSubCategory").text('');
                    $("#lblSubCategory").hide();
                }
                return false;
            });
        }

        function SaveItem() {
            $("[id*=btnItems]").click(function () {
                var catename = '';
                var subcatename = '';
                $('#tblCategory > tbody  > tr').each(function (index, tr) {
                    var selected = $(this).hasClass("highlight");
                    if (selected) {
                        catename = $.trim($(this)[0].textContent);
                    }
                });
                $('#tblSubCategory > tbody  > tr').each(function (index, tr) {
                    var selected = $(this).hasClass("highlight");
                    if (selected) {
                        subcatename = $.trim($(this)[0].textContent);
                    }
                });
                if (catename != "" && subcatename != "") {
                    $('#modal_Item').modal('toggle');
                    $("#editItemModalLabel").text('Save Item');
                    $("#lblItemCategoryName").text(catename);
                    $("#lblItemSubCategoryName").text(subcatename);
                    $("#txtOpening").val('0');
                    $("#lblOpening").text('');
                    $("#lblOpening").hide();
                    $("#txtOptimun").val('0');
                    $("#lblOptimun").text('');
                    $("#lblOptimun").hide();
                    $("#txtReorder").val('0');
                    $("#lblReorder").text('');
                    $("#lblReorder").hide();
                    $("#txtBase").val('0');
                    $("#lblBase").text('');
                    $("#lblBase").hide();
                    $("#txtCostRate").val('0');
                    $("#lblCostRate").text('');
                    $("#lblCostRate").hide();
                    $("#txtItemDescription").val('');
                    $("#lblItemDescription").text('');
                    $("#lblItemDescription").hide();
                }
                else {
                    document.getElementById("m_sweetalert_demo_3_1").click();
                    $("#swal2-title").hide();
                    $("#swal2-content").text('Please select Category & Sub-Category ..!');
                }
                return false;

            });
        }

        function EditSubCategory() {
            $("[id*=editSubCategory_Click]").click(function () {
                var txtSubCategory = $("#txtSubCategory").val();
                var hdn_SubCategory = $("#hdn_SubCategory").val();
                var txtSubCategoryID = 0;
                var txtCategory = 0;

                if (hdn_SubCategory != 'save') {
                    $('#tblSubCategory > tbody  > tr').each(function (index, tr) {
                        var selected = $(this).hasClass("highlight");
                        if (selected) {
                            txtSubCategoryID = $(this)[0].id;
                        }
                    });

                    $('#tblCategory > tbody  > tr').each(function (index, tr) {
                        var selected = $(this).hasClass("highlight");
                        if (selected) {
                            txtCategory = $.trim($(this)[0].textContent);
                        }
                    });
                }

                if (txtSubCategory != "") {
                    var dataString = {
                        'txtSubCategoryID': txtSubCategoryID,
                        'txtSubCategory': txtSubCategory,
                        'Category': txtCategory,
                    };
                    var param = JSON.stringify(dataString);
                    $.ajax({
                        type: 'POST',
                        url: 'General_Master2.aspx/SubCategorySave_Click',
                        data: param,
                        contentType: 'application/json; charset=utf-8',
                        datatype: 'json',
                        success: function (response) {
                            if (response.d[1]) {
                                if (txtSubCategoryID > 0) {
                                    $('#tblSubCategory > tbody  > tr').each(function (index, tr) {
                                        var selected = $(this).hasClass("highlight");
                                        if (selected) {
                                            $(this).replaceWith(response.d[1]);
                                            $("#hdn_SubCategory").val('');
                                            $("#modal_SubCategory").modal('hide');
                                        }
                                    });
                                } else {
                                    $("#tblSubCategory").append(response.d[1]);
                                    $("#modal_SubCategory").modal('hide');
                                }
                            }
                            else if (response.d[2]) {
                                $("#lblSubCategory").text('');
                                $("#lblSubCategory").text(response.d[2]);
                                $("#lblSubCategory").show();
                            }
                            else if (response.d[3]) {
                                $("#lblSubCategory").text('');
                                $("#lblSubCategory").text(response.d[3]);
                                $("#lblSubCategory").show();
                            }
                        },
                        error: function (xhr, status, error) {
                        }
                    });
                    return false;
                } else {
                    $("#lblSubCategory").text('');
                    $("#lblSubCategory").text('Please enter sub category');
                    $("#lblSubCategory").show();
                }
            });
        }

        function EditCategory() {
            $("[id*=editCategory_Click]").click(function () {
                var hdn_Category = $("#hdn_Category").val();
                var txtCategory = $("#txtCategory").val();
                var txtCategoryID = 0;

                if (hdn_Category != 'save') {
                    $('#tblCategory > tbody  > tr').each(function (index, tr) {
                        var selected = $(this).hasClass("highlight");
                        if (selected) {
                            txtCategoryID = $(this)[0].id;
                        }
                    });
                }
                if (txtCategory != "") {
                    var dataString = {
                        'txtCategoryID': txtCategoryID,
                        'txtCategory': txtCategory,
                    };
                    var param = JSON.stringify(dataString);
                    $.ajax({
                        type: 'POST',
                        url: 'General_Master2.aspx/CategorySave_Click',
                        data: param,
                        contentType: 'application/json; charset=utf-8',
                        datatype: 'json',
                        success: function (response) {
                            if (response.d[1]) {
                                if (txtCategoryID > 0) {
                                    $('#tblCategory > tbody  > tr').each(function (index, tr) {
                                        var selected = $(this).hasClass("highlight");
                                        if (selected) {
                                            $(this).replaceWith(response.d[1]);
                                            $("#hdn_Category").val('');
                                            $("#modal_Category").modal('hide');
                                        }
                                    });
                                } else {
                                    $("#tbodyCategory").append(response.d[1]);
                                    $("#modal_Category").modal('hide');
                                }
                            }
                            else if (response.d[2]) {
                                $("#lblCategory").text('');
                                $("#lblCategory").text(response.d[2]);
                                $("#lblCategory").show();
                            }
                            else if (response.d[3]) {
                                $("#lblCategory").text('');
                                $("#lblCategory").text(response.d[3]);
                                $("#lblCategory").show();

                            }
                        },
                        error: function (xhr, status, error) {
                        }
                    });
                    return false;
                } else {
                    $("#lblCategory").text('');
                    $("#lblCategory").text('Please enter category');
                    $("#lblCategory").show();
                }
            });
        }

        function EditItem() {
            $("#editItem_Click").click(function () {
                var hdn_Item = $("#hdn_Item").val();
                var txtOpening = $("#txtOpening").val();
                var txtItemDescription = $("#txtItemDescription").val();
                var txtOptimun = $("#txtOptimun").val();
                var txtReorder = $("#txtReorder").val();
                var txtBase = $("#txtBase").val();
                var txtCostRate = $("#txtCostRate").val();
                var txtDepartment = $("#ddl_Department").val();
                var txtCategoryID = 0;
                var txtSubCategoryID = 0;
                var txtItemID = 0;

                if (hdn_Item != 'save') {
                    $('#tblCategory > tbody  > tr').each(function (index, tr) {
                        var selected = $(this).hasClass("highlight");
                        if (selected) {
                            txtCategoryID = $.trim($(this)[0].textContent);
                        }
                    });
                    $('#tblSubCategory > tbody  > tr').each(function (index, tr) {
                        var selected = $(this).hasClass("highlight");
                        if (selected) {
                            txtSubCategoryID = $.trim($(this)[0].textContent);
                        }
                    });
                    $('#tblItems > tbody  > tr').each(function (index, tr) {
                        var selected = $(this).hasClass("highlight");
                        if (selected) {
                            txtItemID = $(this)[0].id;
                        }
                    });
                }

                if (txtItemDescription != "" || txtDepartment != "0") {
                    if (txtItemDescription != "") {
                        if (txtDepartment != "0") {
                            var dataString = {
                                'CategoryID': txtCategoryID,
                                'SubCategoryID': txtSubCategoryID,
                                'ItemID': txtItemID,
                                'ItemDesc': txtItemDescription,
                                'DeptID': txtDepartment,
                                'Opening': txtOpening,
                                'Optimum': txtOptimun,
                                'Reorder': txtReorder,
                                'Base': txtBase,
                                'CostRate': txtCostRate,
                            };
                            var param = JSON.stringify(dataString);
                            $.ajax({
                                type: 'POST',
                                url: 'General_Master2.aspx/ItemSave_Click',
                                data: param,
                                contentType: 'application/json; charset=utf-8',
                                datatype: 'json',
                                success: function (response) {
                                    if (response.d[1]) {
                                        if (txtCategoryID > 0) {
                                            $('#tblItems > tbody  > tr').each(function (index, tr) {
                                                var selected = $(this).hasClass("highlight");
                                                if (selected) {
                                                    $(this).replaceWith(response.d[1]);
                                                    $("#modal_Item").modal('hide');
                                                }
                                            });
                                        } else {
                                            $("#tblItems").append(response.d[1]);
                                            $("#hdn_Item").val('');
                                            $("#modal_Item").modal('hide');
                                        }
                                    }
                                    else if (response.d[2]) {
                                        $("#lblAllItems").text('');
                                        $("#lblAllItems").text(response.d[2]);
                                        $("#lblAllItems").show();
                                    }
                                    else if (response.d[3]) {
                                        $("#lblAllItems").text('');
                                        $("#lblAllItems").text(response.d[3]);
                                        $("#lblAllItems").show();
                                    }
                                },
                                error: function (xhr, status, error) {
                                }
                            });
                            return false;
                        } else {
                            $("#lblddl_Department").text('');
                            $("#lblddl_Department").text('Please enter Description');
                            $("#lblddl_Department").show();
                        }
                    } else {
                        $("#lblItemDescription").text('');
                        $("#lblItemDescription").text('Please enter Description');
                        $("#lblItemDescription").show();
                    }
                } else {
                    $("#lblddl_Department").text('');
                    $("#lblddl_Department").text('Please enter Description');
                    $("#lblddl_Department").show();
                    $("#lblItemDescription").text('');
                    $("#lblItemDescription").text('Please enter Description');
                    $("#lblItemDescription").show();
                }
            });
        }

        function editCategory(data) {
            $('#modal_Category').modal('toggle');
            $("#editCategoryModalLabel").text('Edit Category');
            $("#txtCategory").val(data.dataset.name);
        }

        function editSubCategory(data) {
            $('#modal_SubCategory').modal('toggle');
            $("#editSubCategoryModalLabel").text('Edit Sub Category');
            $("#txtSubCategory").val(data.dataset.name);
            $("#lblSubCategoryName").text(data.dataset.category);
        }

        function editItem(data) {
            $('#modal_Item').modal('toggle');
            $("#editItemModalLabel").text('Edit Item');
            $("#lblItemCategoryName").text(data.dataset.category);
            $("#lblItemSubCategoryName").text(data.dataset.subcategory);
            $("#ddl_Department").val(data.dataset.department);
            $("#txtOpening").val(data.dataset.opening);
            $("#txtOptimun").val(data.dataset.optimum);
            $("#txtReorder").val(data.dataset.reorder);
            $("#txtBase").val(data.dataset.base);
            $("#txtCostRate").val(data.dataset.cost);
            $("#txtItemDescription").val(data.dataset.description);
        }

        function deleteSubCategory(data) {
            var dataString = {
                'txtSubCategoryID': data.dataset.id,
            };
            var param = JSON.stringify(dataString);
            Swal.fire({
                title: 'Are you sure?',
                text: "You won't be able to revert this!",
                icon: 'warning',
                showCancelButton: true,
                confirmButtonColor: '#3085d6',
                cancelButtonColor: '#d33',
                confirmButtonText: 'Yes, delete it!'
            }).then((result) => {
                if (result.value) {
                    $.ajax({
                        type: 'POST',
                        url: 'General_Master2.aspx/DeleteSubCategory',
                        data: param,
                        contentType: 'application/json; charset=utf-8',
                        datatype: 'json',
                        success: function (response) {
                            if (response.d[1]) {
                                $('#tblSubCategory > tbody  > tr').each(function (index, tr) {
                                    var selected = $(this).hasClass("highlight");
                                    if (selected) {
                                        $(this).remove();
                                    }
                                });
                                Swal.fire(
                                    'Deleted!',
                                    'Your data has been deleted.',
                                    'success'
                                )
                            }
                            else if (response.d[2]) {
                            }
                        },
                        error: function (xhr, status, error) {
                        }
                    });
                }
                else if (result.dismiss === Swal.DismissReason.cancel) {
                    Swal.fire(
                        'Cancelled',
                        'Your data is safe :)',
                        'error'
                    )
                }
            });
        }

        function deleteCategory(data) {
            var dataString = {
                'txtCategoryID': data.dataset.id,
            };
            var param = JSON.stringify(dataString);
            Swal.fire({
                title: 'Are you sure?',
                text: "You won't be able to revert this!",
                icon: 'warning',
                showCancelButton: true,
                confirmButtonColor: '#3085d6',
                cancelButtonColor: '#d33',
                confirmButtonText: 'Yes, delete it!'
            }).then((result) => {
                if (result.value) {
                    $.ajax({
                        type: 'POST',
                        url: 'General_Master2.aspx/DeleteCategory',
                        data: param,
                        contentType: 'application/json; charset=utf-8',
                        datatype: 'json',
                        success: function (response) {
                            if (response.d[1]) {
                                $('#tblCategory > tbody  > tr').each(function (index, tr) {
                                    var selected = $(this).hasClass("highlight");
                                    if (selected) {
                                        $(this).remove();
                                    }
                                });
                                Swal.fire(
                                    'Deleted!',
                                    'Your data has been deleted.',
                                    'success'
                                )
                            }
                            else if (response.d[2]) {
                            }
                        },
                        error: function (xhr, status, error) {
                        }
                    });
                }
                else if (result.dismiss === Swal.DismissReason.cancel) {
                    Swal.fire(
                        'Cancelled',
                        'Your data is safe :)',
                        'error'
                    )
                }
            });
        }

        function deleteItem(data) {
            var dataString = {
                'txtItemID': data.dataset.id,
            };
            var param = JSON.stringify(dataString);
            Swal.fire({
                title: 'Are you sure?',
                text: "You won't be able to revert this!",
                icon: 'warning',
                showCancelButton: true,
                confirmButtonColor: '#3085d6',
                cancelButtonColor: '#d33',
                confirmButtonText: 'Yes, delete it!'
            }).then((result) => {
                if (result.value) {
                    $.ajax({
                        type: 'POST',
                        url: 'General_Master2.aspx/DeleteItem',
                        data: param,
                        contentType: 'application/json; charset=utf-8',
                        datatype: 'json',
                        success: function (response) {
                            if (response.d[1]) {
                                $('#tblItems > tbody  > tr').each(function (index, tr) {
                                    var selected = $(this).hasClass("highlight");
                                    if (selected) {
                                        $(this).remove();
                                    }
                                });
                                Swal.fire(
                                    'Deleted!',
                                    'Your data has been deleted.',
                                    'success'
                                )
                            }
                            else if (response.d[2]) {
                            }
                        },
                        error: function (xhr, status, error) {
                        }
                    });
                }
                else if (result.dismiss === Swal.DismissReason.cancel) {
                    Swal.fire(
                        'Cancelled',
                        'Your data is safe :)',
                        'error'
                    )
                }
            });
        }

        function ShowItems() {
            $('#divSubCategory').on('click', 'table tr', function () {
                var selected = $(this).hasClass("highlight");
                if (!selected)
                    $("#tblSubCategory tr").removeClass("highlight");
                if (!selected)
                    $(this).addClass("highlight");

                var SubCatetable = document.getElementById("tblSubCategory");
                var SubCaterowID = $("#tblSubCategory tr").index(this);
                var Subrow = SubCatetable.rows[SubCaterowID];
                var SubCategory = Subrow.cells[0].innerHTML;
                var Category = '';

                $('#tblCategory > tbody  > tr').each(function (index, tr) {
                    var selected = $(this).hasClass("highlight");
                    if (selected) {
                        Category = $.trim($(this)[0].textContent);
                    }
                });

                var dataString = {
                    'Category': Category,
                    'SubCategory': SubCategory
                };
                var param = JSON.stringify(dataString);

                $.ajax({
                    type: 'POST',
                    url: 'General_Master2.aspx/Item_bindgrid',
                    data: param,
                    contentType: 'application/json; charset=utf-8',
                    datatype: 'json',
                    success: function (response) {
                        document.getElementById("tbodyItem").innerHTML = response.d;
                    },
                    error: function (xhr, status, error) {

                    }
                });

            });
        }

        function ShowSubCategory() {
            $('#divCategory').on('click', 'table tr', function () {
                var table = document.getElementById("tblCategory");
                var rowID = $("#tblCategory tr").index(this);

                var row = table.rows[rowID];
                var CategoryID;
                CategoryID = row.cells[0].innerHTML;

                var selected = $(this).hasClass("highlight");
                if (!selected)
                    $("#tblCategory tr").removeClass("highlight");
                if (!selected)
                    $(this).addClass("highlight");

                var dataString = { 'Category': CategoryID };
                var param = JSON.stringify(dataString);
                var row = "";
                $.ajax({
                    type: 'POST',
                    url: 'General_Master2.aspx/SubCategory_bindgrid',
                    data: param,
                    contentType: 'application/json; charset=utf-8',
                    datatype: 'json',
                    success: function (response) {
                        document.getElementById("tbodySubCategory").innerHTML = response.d;
                    },
                    error: function (xhr, status, error) {

                    }
                });

            });
        }

        function ShowCategory() {
            var dataString = {
                'txtName': '',
            };
            var param = JSON.stringify(dataString);
            $.ajax({
                type: 'POST',
                url: "General_Master2.aspx/Category_bindgrid",
                data: param,
                contentType: 'application/json; charset=utf-8',
                datatype: 'json',
                success: function (response) {
                    document.getElementById("tbodyCategory").innerHTML = response.d;
                },
                failure: function (response) {
                }
            });
        }

    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">


    <div runat="server" id="FrmMain">
        <cc1:ToolkitScriptManager runat="server">
        </cc1:ToolkitScriptManager>

        <%--<button type="button" runat="server" id="btnoo" onserverclick="btnoo_Click" class="btn btn-accent mr-auto" style="display: none" clientidmode="Static">Save</button>--%>


        <asp:HiddenField ID="hdnEditTableClicked" runat="server" ClientIDMode="Static" />
        <asp:HiddenField ID="hdnEditClickedID" runat="server" ClientIDMode="Static" />

        <asp:HiddenField ID="HiddenField1" runat="server" ClientIDMode="Static" />

        <asp:HiddenField ID="hdnCategory" runat="server" ClientIDMode="Static" />
        <asp:HiddenField ID="hdnLocation" runat="server" ClientIDMode="Static" />
        <asp:HiddenField ID="hdnCategoryName" runat="server" ClientIDMode="Static" />
        <asp:TextBox ID="hdnTxtSubCategory" runat="server" Style="display: none;" ClientIDMode="Static"></asp:TextBox>
        <asp:TextBox ID="hdnTxtCategory" runat="server" Style="display: none;" ClientIDMode="Static"></asp:TextBox>
        <%-- <asp:ScriptManager ID="scriptmanager1" runat="server">
        </asp:ScriptManager>--%>

        <div class="m-grid__item m-grid__item--fluid m-wrapper">



            <div class="m-content">
                <div class="row">
                    <div class="col-md-4">
                        <div class="m-portlet">
                            <div class="m-portlet__head p-3">
                                <div class="m-portlet__head-caption">
                                    <div class="m-portlet__head-title">
                                        <span class="m-portlet__head-icon">
                                            <i class="flaticon-placeholder-2"></i>
                                        </span>
                                        <h3 class="m-portlet__head-text">Category
                                        </h3>
                                    </div>
                                </div>
                                <div class="m-portlet__head-tools">
                                    <ul class="m-portlet__nav">
                                        <li class="m-portlet__nav-item">
                                            <asp:LinkButton class="btn m-btn m-btn--gradient-from-primary m-btn--gradient-to-info" runat="server" ID="btnCategory">
                                            <div class="m-demo-icon__preview">
														<i class="la la-plus"></i>
													</div>
                                            </asp:LinkButton>
                                        </li>
                                    </ul>
                                </div>
                            </div>
                            <div id="divCategory" class="m-portlet__body">
                                <table id="tblCategory" class="table table-sm m-table m-table--head-bg-brand">
                                    <tbody id="tbodyCategory">
                                    </tbody>
                                </table>
                            </div>
                        </div>
                    </div>

                    <div class="col-md-4">
                        <div class="m-portlet">
                            <div class="m-portlet__head p-3">
                                <div class="m-portlet__head-caption">
                                    <div class="m-portlet__head-title">
                                        <span class="m-portlet__head-icon">
                                            <i class="flaticon-placeholder-2"></i>
                                        </span>
                                        <h3 class="m-portlet__head-text">Sub Category
                                        </h3>
                                    </div>
                                </div>
                                <div class="m-portlet__head-tools">
                                    <ul class="m-portlet__nav">
                                        <li class="m-portlet__nav-item">
                                            <asp:LinkButton OnClientClick="return confirmSubCategoryAction()"
                                                class="btn m-btn m-btn--gradient-from-primary m-btn--gradient-to-info" runat="server" ID="btnSubCategory">
                                            <div class="m-demo-icon__preview">
														<i class="la la-plus"></i>
													</div>
                                            </asp:LinkButton>

                                        </li>
                                    </ul>
                                </div>
                            </div>
                            <div id="divSubCategory" class="m-portlet__body">
                                <table id="tblSubCategory" class="table table-sm m-table m-table--head-bg-brand">
                                    <tbody id="tbodySubCategory">
                                    </tbody>
                                </table>
                            </div>
                        </div>
                    </div>

                    <div class="col-md-4">
                        <div class="m-portlet">
                            <div class="m-portlet__head p-3">
                                <div class="m-portlet__head-caption">
                                    <div class="m-portlet__head-title">
                                        <span class="m-portlet__head-icon">
                                            <i class="flaticon-placeholder-2"></i>
                                        </span>
                                        <h3 class="m-portlet__head-text">Item
                                        </h3>
                                    </div>
                                </div>
                                <div class="m-portlet__head-tools">
                                    <ul class="m-portlet__nav">
                                        <li class="m-portlet__nav-item">
                                            <asp:LinkButton OnClientClick="javascript:return confirmItemAction();"
                                                class="btn m-btn m-btn--gradient-from-primary m-btn--gradient-to-info" runat="server" ID="btnItems">
                                            <div class="m-demo-icon__preview">
														<i class="la la-plus"></i>
													</div>
                                            </asp:LinkButton>

                                        </li>
                                    </ul>
                                </div>
                            </div>
                            <div id="divItems" class="m-portlet__body">
                                <table id="tblItems" class="table table-sm m-table m-table--head-bg-brand">
                                    <tbody id="tbodyItem">
                                    </tbody>
                                </table>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
        <%--</div>--%>


        <div class="modal fade" id="modal_Category" tabindex="-1" role="dialog" aria-labelledby="exampleModalLabel" style="display: block; padding-right: 16px;">
            <div class="modal-dialog modal-dialog-centered modal-sm" role="document">
                <div class="modal-content">
                    <div class="modal-header">
                        <h5 class="modal-title" id="editCategoryModalLabel">Edit Category</h5>
                        <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                            <span aria-hidden="true">×</span>
                        </button>
                    </div>
                    <div class="modal-body">
                        <div class="form-group">
                            <input type="hidden" id="hdn_Category" />
                            <label for="txtCategory" class="form-control-label">Category :</label>
                            <input placeholder="Enter Category" type="text" class="form-control m-input m-input--air" id="txtCategory" />
                            <label id="lblCategory" style="color: Red; display: block; text-align: center;" for="txtCategory"></label>
                        </div>
                    </div>
                    <div class="modal-footer">
                        <button type="button" class="btn btn-danger" data-dismiss="modal">Close</button>
                        <button type="button" class="btn btn-primary" id="editCategory_Click">Save</button>
                    </div>
                </div>
            </div>
        </div>

        <div class="modal fade" id="modal_SubCategory" tabindex="-1" role="dialog" aria-labelledby="exampleModalLabel" style="display: block; padding-right: 16px;">
            <div class="modal-dialog modal-dialog-centered modal-sm" role="document">
                <div class="modal-content">
                    <div class="modal-header">
                        <h5 class="modal-title" id="editSubCategoryModalLabel">Edit Sub Category</h5>
                        <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                            <span aria-hidden="true">×</span>
                        </button>
                    </div>
                    <div class="modal-body">
                        <div class="form-group">
                            <label class="form-control-label">Category :</label>
                            <label id="lblSubCategoryName" style="font-weight: bold; margin-left: 10px"></label>
                        </div>
                        <div class="form-group">
                            <input type="hidden" id="hdn_SubCategory" />
                            <label for="txtSubCategory" class="form-control-label">Sub Category :</label>
                            <input placeholder="Enter Sub Category" type="text" class="form-control m-input m-input--air" id="txtSubCategory" />
                            <label id="lblSubCategory" style="color: Red; display: block; text-align: center;" for="txtSubCategory"></label>
                        </div>

                    </div>
                    <div class="modal-footer">
                        <button type="button" class="btn btn-danger" data-dismiss="modal">Close</button>
                        <button type="button" class="btn btn-primary" id="editSubCategory_Click">Save</button>
                    </div>
                </div>
            </div>
        </div>

        <div class="modal fade" id="modal_Item" tabindex="-1" role="dialog" aria-labelledby="exampleModalLabel" style="display: block; padding-right: 16px;">
            <div class="modal-dialog modal-lg" role="document">
                <div class="modal-content">
                    <div class="modal-header">
                        <h5 class="modal-title" id="editItemModalLabel">Edit Item</h5>
                        <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                            <span aria-hidden="true">×</span>
                        </button>
                    </div>
                    <div class="modal-body">
                        <div class="m-portlet__body">
                            <div class="form-group m-form__group row">
                                <label class="col-lg-2 form-control-label">Category :</label>
                                <div class="col-lg-4">
                                    <label id="lblItemCategoryName" class="form-text" style="font-weight: bold;"></label>
                                </div>
                                <label class="col-lg-2 form-control-label">Sub Category :</label>
                                <div class="col-lg-4">
                                    <label id="lblItemSubCategoryName" class="form-text" style="font-weight: bold;"></label>
                                </div>
                            </div>
                            <div class="form-group m-form__group row">
                                <label class="col-lg-2 col-form-label">Description :</label>
                                <div class="col-lg-10">
                                    <div class="m-input-icon m-input-icon--right">
                                        <input type="hidden" id="hdn_Item" />
                                        <input placeholder="Enter Description" type="text" class="form-control" id="txtItemDescription" />
                                        <label id="lblItemDescription" style="color: Red; display: block; text-align: center;" for="txtSubCategory"></label>
                                    </div>
                                </div>

                            </div>
                            <div class="form-group m-form__group row">
                                <label class="col-lg-2 col-form-label">Department :</label>
                                <div class="col-lg-4">
                                    <div class="m-input-icon m-input-icon--right">
                                        <select class="form-control m-input" id='ddl_Department'></select>
                                        <label id="lblddl_Department" style="color: Red; display: block; text-align: center;" for="ddl_Department"></label>
                                    </div>
                                </div>
                                <label class="col-lg-2 col-form-label">Opening :</label>
                                <div class="col-lg-4">
                                    <div class="m-input-icon m-input-icon--right">
                                        <input placeholder="Enter Opening" type="text" class="form-control" id="txtOpening" />
                                        <label id="lblOpening" style="color: Red; display: block; text-align: center;" for="txtOpening"></label>
                                    </div>
                                </div>

                            </div>
                            <div class="form-group m-form__group row">
                                <label class="col-lg-2 col-form-label">Optimun :</label>
                                <div class="col-lg-4">
                                    <div class="m-input-icon m-input-icon--right">
                                        <input placeholder="Enter Optimun" type="text" class="form-control" id="txtOptimun" />
                                        <label id="lblOptimun" style="font-weight: bold; margin-left: 10px"></label>
                                    </div>
                                </div>
                                <label class="col-lg-2 col-form-label">Re Order :</label>
                                <div class="col-lg-4">
                                    <div class="m-input-icon m-input-icon--right">
                                        <input placeholder="Enter Reorder" type="text" class="form-control" id="txtReorder" />
                                        <label id="lblReorder" style="color: Red; display: block; text-align: center;" for="txtReorder"></label>
                                    </div>
                                </div>

                            </div>
                            <div class="form-group m-form__group row">
                                <label class="col-lg-2 col-form-label">Base :</label>
                                <div class="col-lg-4">
                                    <div class="m-input-icon m-input-icon--right">
                                        <input placeholder="Enter Base" type="text" class="form-control" id="txtBase" />
                                        <label id="lblBase" style="font-weight: bold; margin-left: 10px"></label>
                                    </div>
                                </div>
                                <label class="col-lg-2 col-form-label">Cost Rate :</label>
                                <div class="col-lg-4">
                                    <div class="m-input-icon m-input-icon--right">
                                        <input placeholder="Enter Sub Category" type="text" class="form-control" id="txtCostRate" />
                                        <label id="lblCostRate" style="font-weight: bold; margin-left: 10px"></label>
                                    </div>
                                </div>
                            </div>
                            <label id="lblAllItems" style="color: Red; display: block; text-align: center;"></label>

                        </div>

                    </div>
                    <div class="modal-footer">
                        <button type="button" class="btn btn-danger" data-dismiss="modal">Close</button>
                        <button type="button" class="btn btn-primary" id="editItem_Click">Save</button>
                    </div>
                </div>
            </div>
        </div>


        <!-- end:: Body -->

        <!-- begin::Scroll Top -->
        <div id="m_scroll_top" class="m-scroll-top">
            <i class="la la-arrow-up"></i>
        </div>

        <!-- end::Scroll Top -->

    </div>

</asp:Content>

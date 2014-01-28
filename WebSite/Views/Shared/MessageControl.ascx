<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl" %>
<!-- 用户确认框 -->
<aside id="confirm" class="modal hide fade" tabindex="-1" role="dialog" aria-labelledby="myModalLabel" aria-hidden="true">
    <div class="modal-header">
        <button type="button" class="close" data-dismiss="modal" aria-hidden="true">&times;</button>
        <h3 id="myModalLabel">Modal Heading</h3>
    </div>
    <div class="modal-body">
        One fine body…
    </div>
    <div class="modal-footer">
        <button class="btn btn-danger" data-dismiss="modal">Close</button>
        <button class="btn btn-primary">Save changes</button>
    </div>
</aside>

<!-- 成功提示 -->
<aside id="success" class="modal hide fade success" tabindex="-1" role="dialog" aria-labelledby="myModalLabel" aria-hidden="true">
<div class="modal-header">
<button type="button" class="close" data-dismiss="modal" aria-hidden="true">&times;</button>
<h3 id="H1">操作成功</h3>
</div>
<div class="modal-body">
<span id="successMessage" class="successMessage"></span>
</div>
<div class="modal-footer">
<button class="btn btn-primary" data-dismiss="modal">确定</button>
</div>
</aside>

<!-- 错误提示 -->
<aside id="error" class="modal top hide fade error" tabindex="-1" role="dialog" aria-labelledby="myModalLabel" aria-hidden="true">
<div class="modal-body">
<p><span id="errorMessage" class="errorMessage"></span></p>
</div>
<div class="modal-footer">
<button class="btn btn-danger btn-large" data-dismiss="modal">Close</button>
</div>
</aside>

<!-- loading 画面 -->
<div id="loading-div-background">
    <div id="loading-div" class="ui-corner-all" >
      <img style="height:80px;margin:30px;" src="../../assets/img/loadingGIF.gif" alt="读取中,请稍候.."/>
     </div>
</div>

<style>
#loading-div-background 
    {
        display:none;
        position:fixed;
        top:0;
        left:0;
        background:black;
        width:100%;
        height:100%;
     }
</style>
<style>
    #loading-div
    {
         background-color: black;
         text-align:center;
         position:absolute;
         left: 50%;
         top: 50%;
         margin-left:-150px;
         margin-top: -100px;
     }
</style>
<script src="../../assets/js/jquery-1.9.1.min.js"></script>
<script type="text/javascript">
    $(document).ready(function () {
        $("#loading-div-background").css({ opacity: 0.8 });
    });

    function ShowProgressAnimation() {
        $("#loading-div-background").show();
    }

    function HideProgressAnimation() {
        $("#loading-div-background").hide();
    }

    </script>
<script type="text/javascript">
    function showSuccess(msg) {

        $(".successMessage").html(msg);
        $(".success").modal("show");
    }

    //  操作失败提示
    function showError(msg) {
        $(".errorMessage").html(msg);
        $(".error").modal("show");
    }

    function showLoading() {
        $(".loading").modal("show");
    }
    function hideLoading() {
        $(".loading").modal("hide");
    }
</script>
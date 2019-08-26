$(function() {

    if ($(".form_text_ipt input.name").val() === "" || $(".form_text_ipt input.password").val() === "") {
        $(".form_btn button").attr("disabled", true);
    } else {
        $(".form_btn button").attr("disabled", false);
    }
    //登录输入框效果
    $(".form_text_ipt input").focus(function() {
        $(this).parent().css({
            'box-shadow': "0 0 3px #1891ff"
        });
        $(this).parent().css({
            'border': "solid 1px #ccc"
        });
    });
    $(".form_text_ipt input").blur(function() {
        if ($(this).val() === "") {
            $(this).parent().css({
                'border': "solid 1px red"
            });
            $(this).parent().next().show();
        }
        $(this).parent().css({
            'box-shadow': "none"
        });
        //$(this).parent().next().hide();

    });
    $(".form_text_ipt input").blur(function() {
        $(this).parent().css({
            'box-shadow': "none"
        });
        //$(this).parent().next().hide();
    });

    //表单验证
    $(".form_text_ipt input").bind("input propertychange",
        function() {
            if ($(this).val() === "") {
                $(this).parent().css({
                    'border': "solid 1px red",
                    'box-shadow': "0 0 3px red"
                });
                $(this).parent().next().show();
            } else {
                $(this).parent().css({
                    'border': "solid 1px #ccc"
                });
                $(this).parent().next().hide();
            }
            if ($(".form_text_ipt input.name").val() === "" || $(".form_text_ipt input.password").val() === "") {
                $(".form_btn button").attr("disabled", true);
            } else {
                $(".form_btn button").attr("disabled", false);
            }
        });

});
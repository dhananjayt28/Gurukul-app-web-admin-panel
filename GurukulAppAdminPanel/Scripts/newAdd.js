//  var _clickTriger = document.querySelector("MouTargetConfigure");
////var _Openpopup = document.getElementById("View_popAddTarget");
// _clickTriger.addEventListener('click',function(){
//     $("#View_popAddTarget").show();
// })
/******Navbar Active***************/
//$(document).ready(function () {
//    $('.panel-collapse').click(function (e) {
//        e.preventDefault();
//        $('.panel-collapse').removeClass('active');
//        $(this).addClass('active');
//    });
//});
//navbar fixed

//Profile added Js		
$(document).ready(function () {
    $('.change_password_Btn').each(function (e, f) {
        $(this).on('click', function () {
            
            $('.limiter').fadeIn().each(function () {
                $(".changes-password-closeBtn").on("click", function () {
                    $('.limiter').fadeOut();
                })
            })
        })
    })
    $('.formChange_box').addClass('animated bounceInDown');
    $('.slide_imgCover.text-center h1').addClass('animated fadeInDown');
    $('.slide_imgCover.text-center h3').addClass('animated fadeInUp');
});
$(document).on('click', '.change_password_Btn,.login_button', function () {
    $("body").css({
        overflow: "hidden"
    })

})
$(document).on("click", '.changes-password-closeBtn,.closeBtn_popup', function () {
    $("body").css({
        overflow: "scroll"
    })
})
$(document).ready(function () {
    $("#loginBtn").click(function () {
        $("#showLogin").fadeIn("slow");
    })
})
$(document).ready(function () {
    $(".closeBtn_popup").click(function () {
        $("#showLogin").fadeOut("slow");
    })
})
  
/*****End Navbar Active****************/

/*******Add Activity js************/
$(document).on("click", "#btn_chk_add_subActivity", function () {
    var _this = $(this);
    if (_this) {
        $(".div_doyouwant_msg").fadeOut("slow");
    }
   
})

/*****interventions mapping Jqurey******************/
$(document).on("click", ".addMapping_btn,#selectedBtn_panleClose", function () {
     var _addMapping = $(".addMapping_btn");
     //var _closeBtn = $("#selectedBtn_panleClose");
    if (_addMapping) {
        $(".addPartner_mainPanle").css({
            "display": "block"
        })
    }
    //else {
    //    _addMapping.css({
    //        "display": "none"
    //    })

    //}
});
$(document).on("click", "#selectedBtn_panleClose","head", function () {
    var _closePanleBtn = $(this);
    if (_closePanleBtn) {
        $(".addPartner_mainPanle").css({
            "display": "none"
        })
    }
})
/*****interventions mapping Jqurey******************/
$(document).on("click", ".dropdown", function () {
    var _droupAdmin = $(this);
    if (_droupAdmin) {
        $(".dropdown-content").fadeToggle("500");
    }
});
$(window).on("load", function () {
    //var preLoder = $(this);
    $(".preLoder").delay('500').fadeOut('slow');
});
$(document).on("click", ".icon_menu", function () {
    var openNav = $(this);
    if (openNav) {
        $(".left_navbar_panle").fadeToggle("500");
    }
})
 

$(document).ready(function(){
    $(".MouTargetConfigure").on('click',function(){
        $("#View_popAddTarget").slideDown('100');
        $('.modal-dialog').addClass('animated bounceInDown');
        //$(".datpiker_icon:before").addClass("TxtStartDate");
     
    });
    
    $('#close_btn').on('click',function(){
             $("#View_popAddTarget").fadeOut('100');
        });
    
   
});
$(document).on('click', ".Pro_trClickBtn", function(){
       alert("work");
            $("#open_trBox").fadeIn('100');
    $("#close_btnsu").click(function(){
        $("#open_trBox").fadeOut('100');
    })
});


/****Outcome Popup**********/
$(document).on("click", "#OutcomeModalOpenBtn", function () {
    $("#Outcome_show").fadeIn("slow");
});
$(document).on("click", ".close_pop_button", function () {
    $("#Outcome_show").fadeOut("slow");
})
/*******************End Popup**/

$(document).on("click", "#New_Active_AddBtn", function () {
    var addActivity = $(this);
    $(".addSub_activity").fadeIn("slow");
    
    //Login_Box
   
});

/*******date Piker js**************/
$(document).ready(function () {
    $('#start-date,#end-date,#subActivity-start-date,#subActivity-end-date,#viewActivity_startDate,#viewActivity_endDate,#actual-end-date').datepicker();
})

/*******End date Piker js**************/

/*********viewActivity actions js*********************/
$(document).on("click", ".clickable_Actions", function () {
    var _this = $(this);
    if (_this.hasClass("rotate-180")) {
        _this.removeClass("rotate-180");
    } else {
        _this.addClass("rotate-180");
    }
}); 
  
$(document).on("click", ".clickable_Actions", function () {
    var $this = $(this);
    if ($this.is("i")) {
        //console.log($this);
        var $div = $this.closest("td").children("div.Action_droupicon");
        $div.fadeToggle('500');
    }
})


$(window).resize(function () {
    var _MyprofileBtn = $(".icon_header");
    if ($('.body_row').width() == 320) {

        // is mobile device

    }

});
/*********viewActivity actions js*********************/
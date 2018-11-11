$(function () {
    "use strict"
    var _BaseURL = window.location.origin;
    
    var action_name = !$.isNull($.getactionname()) ? $.getactionname().toLowerCase() : "";
    var getUrlParameter = function getUrlParameter(sParam) {
        var sPageURL = decodeURIComponent(window.location.search.substring(1)),
            sURLVariables = sPageURL.split('&'),
            sParameterName,
            i;

        for (i = 0; i < sURLVariables.length; i++) {
            sParameterName = sURLVariables[i].split('=');

            if (sParameterName[0] === sParam) {
                return sParameterName[1] === undefined ? true : sParameterName[1];
            }
        }
    };
    
    // Using in Event Create Page
    //$("#startDate").datepicker({
    //    changeYear: true,
    //    changeMonth: true,
    //    minDate: 0,
    //    dateFormat: 'dd-mm-yy',
    //    onSelect: function (selected) {
    //        var dt = new Date(selected);
    //        dt.setDate(dt.getDate() + 1);
    //        $("#endDate").datepicker({
    //            changeYear: true,
    //            changeMonth: true,
    //            minDate: dt,               
    //            dateFormat: 'dd-mm-yy',
    //            onSelect: function (selected) {
    //                var dt = new Date(selected);
    //                dt.setDate(dt.getDate());
    //                $("#expireDate").datepicker({
    //                    changeYear: true,
    //                    changeMonth: true,
    //                     minDate: dt,                       
    //                    dateFormat: 'dd-mm-yy'
    //                });
    //            }
    //        });
    //    }
    //});
    //$("#startDate").datepicker({
    //    changeYear: true,
    //    changeMonth: true,
    //    minDate: 0,
    //    dateFormat: 'dd-mm-yy',
    //});
    //$("#endDate").datepicker({
    //    changeYear: true,
    //    changeMonth: true,
    //    minDate: 0,
    //    dateFormat: 'dd-mm-yy',
    //});
    //$("#expireDate").datepicker({
    //    changeYear: true,
    //    changeMonth: true,
    //    minDate: 0,
    //    dateFormat: 'dd-mm-yy',
    //});
    $(".common-date-picker").datepicker({
        changeYear: true,
        changeMonth: true,
        minDate: 0,
        dateFormat: 'dd-mm-yy'
    });
   
    // Using in Event Create Page
    $(document).on("change", "#_event_drpdown", function () {
        var _dropValue = $(this).val();
        var _workshop = $("#GitaAndWorkshop");
        var _gita = $("#GitaDistribute");
        switch (_dropValue) {
            case "1": {
                _workshop.hide();
                _gita.hide();
            } break;
            case "2": {
                _workshop.show();
                _gita.hide();
            } break;
            case "3": {
                _workshop.show();
                _gita.show();
            } break;
            default: {
                _workshop.hide();
                _gita.hide();
            } break;
        }

    });
    //Using in Volunteer Event List
    $(document).on("click", "#showVolunteerProfile", function (e) {

        var thisObj = $(this);
        var _userId = thisObj.data("id");
        
        var modalBlock = $(".common-popup");
        var URL =  _BaseURL + "/user/user-profile-data/" + _userId
        $.getJSON(URL, function (data) {            
            if (data.status) {
                if (data.response !== null) {
                    //user_profile_div
                    var responseData = data.response[0];
                    var _content = '<table class="table table-responsive"><tbody><tr><td>Full Name</td><th>' + responseData.NAME + '</th></tr><tr><td>Date Of Birth</td><th>' + responseData.DOB + '</th></tr><tr><td>Gender</td><th>' + responseData.GENDER + '</th></tr><tr><td>Mobile No</td><th>' + responseData.MOBILE_NO + '</th></tr><tr><td>E-Mail ID</td><th>' + responseData.EMAIL_ID + '</th></tr><tr><td>Satsang Country</td><th>' + responseData.COUNTRY + '</th></tr><tr><td>Satsang Chapter</td><th>' + responseData.SATSANG_CHAPTER + '</th></tr><tr><td>Education</td><th>' + responseData.EDUCATION + '</th></tr><tr><td>City</td><th>' + responseData.CITY + '</th></tr></tbody></table>';
                    //var modalbody = modalBlock.children("div.modal-dialog").children("div.modal-content").children("div.modal-body");
                    //modalbody.html(_content);
                    //modalBlock.modal("show");
                    $("#user_profile_div").html(_content);
                }
                else { $("#user_profile_div").html(null); }
            }
            else {
                $("#user_profile_div").html(null);


            }
            

        });
        //console.log(_BaseURL + "/user/user-profile-data/" + _userId);
    });
    //Using in Volunteer Topic Allocate
    $(document).on("click", "#topicAllocate", function (e) {
        console.log(e);
    });
    /***************************************
    * Title - Load Gridview of view-master
    * Parameter -null
    * Return - gridview
    * Syntax - null
    ***************************************/
    //action_name === 'view-master'
    if (action_name === 'view-master') {
    var jsondata1 =
//{
//    "status": "true"
//},
{
    "response": [
      {
          "USER_ID": "0",
          "Name": "Ayan Nath",
          "Phone no": "8017221809",
          "Email": "ayan@tts.com",
          "USER_STATUS": "Active",
          "USER_ROLE": "Step_Lead",
          "ORG_NAME": "Titan"
      },
      {
          "USER_ID": "1",
          "Name": "Sayan Chatterjee",
          "Phone no": "8017221807",
          "Email": "sayan@tts.com",
          "USER_STATUS": "Blocked",
          "USER_ROLE": "Step_Lead",
          "ORG_NAME": "Titan"
      }

    ]
}
        //$("#add_category_OpenBtn").click(function () {
        //    $("#save_master_category_div").show();
        //    $(this).hide();
        //});

        //$("#cancel_catagory_Btn").click(function () {
        //    $("#save_master_category_div").hide();
        //    $("#add_category_OpenBtn").show();
        //});

        $.ajax({
            url: _BaseURL + "/master/get-master",
            //url: API_BASEURL + 'api/get-master-data-list',
            type: "POST",
            async: false,            
            //crossDomain: true,
            dataType: "json",
            success: function (data) {
                $("#MasterGridview").Gridview(data.response, {
                    autocolumn: false,
                    column: [

                                { name: "CATEGORY MASTER ID", dbcol: "SL_ID" },
                                { name: "CATEGORY MASTER", dbcol: "TYPE" },
                                {
                                    name: "Action",
                                    dbcol: "TYPE",
                                    value: '<a href="javascript:void(0);" class="BtnViewParentMaster" ><i class="fa fa-eye" aria-hidden="true" data-toggle="modal" data-target="#myModal1" id="i_of_master"></i></a>',
                                    data: {
                                        listname: "TYPE"
                                    }
                                },
                                 {
                                     name: "Add Sub Category",
                                     value: '<button id="add_sub_category" class="btn btn-info" data-toggle="modal" data-target="#AddSubMasterCategoryModal"><i class="fa fa-plus-square" aria-hidden="true"></i> </button>',
                                     data: {
                                         catid: "SL_ID"

                                     }
                                 }
                    ],
                    //class: "",
                    //id: "view_Table"
                });
            },
            error: function (errorResponse) {
                if (!errorResponse.response) {
                    errorResponse.response = "network error occurred";
                }
                $.msgbox(errorResponse.response, "error");
            }
        });

        /***************************************
           * Title - Load Gridview of ParentMaster
           * Parameter -null
           * Return - gridview
           * Syntax - null
           ***************************************/
        $(document).on("click", ".BtnViewParentMaster", function () {
            var category_name = $(this).data("listname");
            var $this = $(this);
            var formArray = {};
            formArray["category_name"] = category_name;
            //alert(category_name);
            $.ajax({
                url: _BaseURL + "/master/get-list",
                //url: API_BASEURL + 'api/get-master-data-list?category_name=' + value_of_master,//undone
                type: "POST",
                async: false,
                data: formArray,
                dataType: "json",
                success: function (data) {

                    //var _i_Obj = $this.children("i");
                    //var _tr = $this.closest("tr");
                    //var _sub_tr = $('<tr class="row1 addactivity-row collapse subActivityData in" aria-expanded="true" style=""></tr>');
                    //_sub_tr.append('<td colspan="12"><div id="ViewParentGridview"></div></td>');
                    //_sub_tr.children("td");
                    //_tr.after(_sub_tr);
                    //if (_i_Obj.hasClass("rotate-180")) {


                        $("#ViewParentGridview").Gridview(data.response, {
                            autocolumn: true,
                            //column: [
                            //            { name: "CATEGORY LIST ID", dbcol: "LOV_ID" },
                            //            { name: "CATEGORY LIST", dbcol: "LOV_NAME" }
                            //],
                            //class: "container-fluid Ownershop_background view_activity_table",
                            //id: "view_Table"
                        });
                    //}
                    //else {
                    //    $(".subActivityData").remove();
                    //}
                },
                error: function () {
                    alert("error occurred");

                }
            });
        });


        // Add category name
        $(document).on("click", "#save_catagory_Btn", function () {
            
            var formdata = $.formdata("#AddCategoryName");
            var subtext = $("#TxtSavecategory").val();
            $.ajax({
                type: 'POST',
                url: _BaseURL + '/master/add-category',
                dataType: "json",
                data: formdata,
                processData: false,
                contentType: false,
                success: function (result) {
                   
                    alert(result.response);
                       // $.msgbox(result.response, "success");
                       // $.redirect($.baseurl("master/view-master"));
                    $.ajax({
                        url: _BaseURL + "/master/get-master",
                        //url: API_BASEURL + 'api/get-master-data-list',
                        type: "POST",
                        async: false,
                        //crossDomain: true,
                        dataType: "json",
                        success: function (data) {
                            $("#MasterGridview").Gridview(data.response, {
                                autocolumn: false,
                                column: [

                                            { name: "CATEGORY MASTER ID", dbcol: "SL_ID" },
                                            { name: "CATEGORY MASTER", dbcol: "TYPE" },
                                            {
                                                name: "Action",
                                                dbcol: "TYPE",
                                                value: '<a href="javascript:void(0);" class="BtnViewParentMaster" ><i class="fa fa-eye clickable material-icons hand" aria-hidden="true" data-toggle="modal" data-target="#myModal1" id="i_of_master"></i></a>',
                                                data: {
                                                    listname: "TYPE"
                                                }
                                            },
                                             {
                                                 name: "Add Sub Category",
                                                 value: '<button id="add_sub_category" class="btn btn-info" data-toggle="modal" data-target="#AddSubMasterCategoryModal"><i class="fa fa-plus-square" aria-hidden="true"></i> </button>',
                                                 data: {
                                                     catid: "SL_ID"

                                                 }
                                             }
                                ],
                                //class: "",
                                //id: "view_Table"
                            });
                        },
                        error: function (errorResponse) {
                            if (!errorResponse.response) {
                                errorResponse.response = "network error occurred";
                            }
                            $.msgbox(errorResponse.response, "error");
                        }
                    });
                    
                },
                error: function (errorThrown) {
                    $.msgbox(errorThrown.responseJSON.response, "error");
                }
            });
        });
        $(document).on("click", "#add_sub_category", function () {
            var cat_id = $(this).data("catid");
            $("#category_id").val(cat_id);
            //alert($("#category_id").val());
        });
        // Add sub category
        //add_sub_category
        $(document).on("click", "#Save_sub_category_btn", function () {
           
            var formdata = $.formdata("#AddSubCategoryForm");
            $.ajax({
                type: 'POST',
                url: _BaseURL + '/master/add-sub-category',
                dataType: "json",
                data: formdata,
                processData: false,
                contentType: false,
                success: function (result) {
                    
                        alert("Data Added Successfully");
                       // $.msgbox(result.response, "success");
                       // $.redirect($.baseurl("master/view-master"));
                    
                    
                },
                error: function (errorThrown) {
                    $.msgbox(errorThrown.responseJSON.response, "error");
                }
            });
        });
    }
    if (action_name === 'iascoaching')
    {
        $.ajax({
            url: _BaseURL + "/iascoaching/get-subject",
            type: "POST",
            async: false,
            dataType: "json",
            success: function (data) {
                $("#subject,#subject_").Dropdown(data.response, {
                    value: {
                        text: "LOV_NAME",
                        value: "LOV_ID"
                    }
                });
            }
        });
    }
    if (action_name === "user-list") 
    {
        $.ajax({
            url: _BaseURL + "/iascoaching/get-bp",
            type: "POST",
            async: false,
            dataType: "json",
            success: function (data) {
                $("#bp_dd").Dropdown(data.response, {
                    value: {
                        text: "LOV_NAME",
                        value: "LOV_ID"
                    }
                });
            }
        });
    }
    //submit_event
    $(document).on("click", "#submit_event", function () {
        //EventMaleNo
        //EventFemaleNo
       var male_no= $("#EventMaleNo").val();
       var female_no = $("#EventFemaleNo").val();
       var start_date = $("#startDate").val();
       var end_date = $("#endDate").val();
       var expiry_date = $("#expireDate").val();
       if (male_no <= 0 || female_no <= 0 || start_date === "" || end_date === "" || expiry_date === "") {
           alert("Plesae enter male and female req no more than 0 and also please put start date,end date and expiry date ");
       }

    });


    //add_ias
    $(document).on("click", "#btn_save", function () {
        var sub_ = $("#subject option:selected").text();
       var date_ = $("#iasMainDate").val();
        //Select Subject
       //alert(sub_);
        //alert(date_);
       if (sub_ === "Select Subject" || date_ === "") {
           alert("Please Put Date and Subject Both");
           return false;
       }
        //if (sub_ === "0" || date_ === "") {
        //    return false;
        //}
       
        var formdata = $.formdata("#add_ias");
        $.ajax({
            url: _BaseURL + "/iascoaching/add-ias",
            type: "POST",
            async: false,
            dataType: "json",
            data: formdata,
            processData: false,
            contentType: false,
            success: function (data) {
                alert(data.response);
                $.ajax({
                    url: _BaseURL + "/iascoaching/get-ias",
                    type: "POST",
                    async: false,
                    dataType: "json",
                    success: function (data) {
                        $("#div_of_Ias").Gridview(data.response, {
                            autocolumn: false,
                            column: [
                                        //{ name: "RECORD SYS ID", dbcol: "RECORD_SYS_ID" },
                                        { name: "SUBJECT", dbcol: "SUBJECT_NAME" },
                                        { name: "COACHING DATE", dbcol: "COACHING_DATE" },
                            {
                                name: "Action",
                                dbcol: "RECORD_SYS_ID",
                                value: '<button type="button" id="update_btn" class="update_btn btn btn-info" data-toggle="modal" data-target="#myModal3"><i class="fa fa-pencil-square-o" aria-hidden="true"></i></button><button type="button" id="delete_btn" class="update_btn btn btn-info" data-toggle="modal" data-target="#myModal6"><i class="fa fa-trash" aria-hidden="true"></i></button>'
                            }
                            ],
                            id: "",
                            

                        });
                    }
                });
            }
        });
    });
    if (action_name === "iascoaching")
    {
        $.ajax({
            url: _BaseURL + "/iascoaching/get-ias",
            type: "POST",
            async: false,
            dataType: "json",
            success: function (data) {
                $("#div_of_Ias").Gridview(data.response, {
                    autocolumn: false,
                    column: [
                                //{ name: "RECORD SYS ID", dbcol: "RECORD_SYS_ID" },
                                { name: "SUBJECT", dbcol: "SUBJECT_NAME" },
                                { name: "COACHING DATE", dbcol: "COACHING_DATE" },
                    {   name: "Action", 
                        dbcol: "RECORD_SYS_ID",
                        value: '<button type="button" id="update_btn" class="update_btn btn btn-info" data-toggle="modal" data-target="#myModal3"><i class="fa fa-pencil-square-o" aria-hidden="true"></i></button><button type="button" id="delete_btn" class="update_btn btn btn-info" data-toggle="modal" data-target="#myModal6"><i class="fa fa-trash" aria-hidden="true"></i></button>'
                    }
                    ],
                    id:""
                    
                });
            }
        });
        $(document).on("click", "#update_btn", function () {
            var $this = $(this);
            var Record_id = $this.val();
            $("#hide_record_id").val(Record_id);
            var formArray = {};
            formArray["Record_id"] = Record_id;
            //iascoaching/get-record
            $.ajax({
                url: _BaseURL + "/iascoaching/get-record",
                type: "POST",
                async: false,
                dataType: "json",
                data: formArray,
                
                success: function (data) {

                    var coaching_date = data.response[0]["COACHING_DATE"];
                    var sub = data.response[0]["SUBJECT_NAME"];
                    var sub_id = data.response[0]["SUBJECT_ID"];
                    $("#subject_ option:selected").text(sub);
                    $("#subject_ option:selected").val(sub_id);
                    //$("#subject_").val(sub);
                    $("#popupdate").val(coaching_date);
                }
            });
        });
        //btn_update_
        $(document).on("click", "#btn_update_", function () {
            var formdata = $.formdata("#update_ias");
            $.ajax({
                url: _BaseURL + "/iascoaching/update-ias",
                type: "POST",
                async: false,
                dataType: "json",
                data: formdata,
                processData: false,
                contentType: false,
                success: function (data) {
                    alert(data.response);
                    $.ajax({
                        url: _BaseURL + "/iascoaching/get-ias",
                        type: "POST",
                        async: false,
                        dataType: "json",
                        success: function (data) {
                            $("#div_of_Ias").Gridview(data.response, {
                                autocolumn: false,
                                column: [
                                            //{ name: "RECORD SYS ID", dbcol: "RECORD_SYS_ID" },
                                            { name: "SUBJECT", dbcol: "SUBJECT_NAME" },
                                            { name: "COACHING DATE", dbcol: "COACHING_DATE" },
                                {
                                    name: "Action",
                                    dbcol: "RECORD_SYS_ID",
                                    value: '<button type="button" id="update_btn" class="update_btn btn btn-info" data-toggle="modal" data-target="#myModal3"><i class="fa fa-pencil-square-o" aria-hidden="true"></i></button><button type="button" id="delete_btn" class="update_btn btn btn-info" data-toggle="modal" data-target="#myModal6"><i class="fa fa-trash" aria-hidden="true"></i></button>'
                                }
                                ],

                            });
                        }
                    });
                }
            });
        });

    }

    if (action_name === "user-list")
    {
        //dd_status
        $.ajax({
            url: _BaseURL + "/user/get-status",
            type: "POST",
            async: false,
            dataType: "json",
            success: function (data) {
                $("#dd_status").Dropdown(data.response, {
                    value: {
                        text: "LOV_NAME",
                        value: "LOV_ID"
                    }
                });
                var ustatus = getUrlParameter('ustatus');
                if (!$.isNull(ustatus))
                {
                    $("#dd_status option:selected").text(ustatus);
                }
            }
        });

        $(document).on("change", "#dd_status", function () {
            var user_status = $("#dd_status option:selected").text();
            //var formArray = {};
            //formArray["user_status"] = user_status;
            $.redirect(_BaseURL + "/user/user-list?ustatus=" + user_status);
            //$.ajax({
            //    url: _BaseURL + "/user/user-list",
            //    type: "POST",
            //    async: false,
            //    dataType: "json",
            //    data: formArray,
            //    success: function (data) {

            //       // $('#userTabledata').DataTable();
            //    }
            //});
        });



    }
    $(document).on("click", ".showEventDetails", function () {
        var $this = $(this);
        var event_id_ = $this.data("id");
        var formArray = {};
        formArray["event_id_"] = event_id_;
        $.ajax({
            url: _BaseURL + "/event/get-event",
            type: "POST",
            async: false,
            dataType: "json",
            data: formArray,
            success: function (data) {
                //************************************
                if (data.status==="true") {
                    if (data.response != null) {
                        var responseData = data.response[0];
                        var _content = '<table class="table table-responsive"><tbody><tr><td>Full Name</td><th>' + responseData.NAME + '</th></tr><tr><td>Registration Start Date</td><th>' + responseData.REG_START_DATE + '</th></tr><tr><td>Registration End Date</td><th>' + responseData.REG_END_DATE + '</th></tr><tr><td>Status</td><th>' + responseData.STATUS + '</th></tr><tr><td>Message</td><th>' + responseData.MESSAGE + '</th></tr><tr><td>Person number</td><th>' + responseData.PERSON_NO + '</th></tr><tr><td>Comment</td><th>' + responseData.COMMENT + '</th></tr><tr><td>Class Val</td><th>' + responseData.CLASS_VAL + '</th></tr><tr><td>Checking Date</td><th>' + responseData.CHECKIN_DATE + '</th></tr><tr><td>Checking Time</td><th>' + responseData.CHECKIN_TIME + '</th></tr><tr><td>Checkout Date</td><th>' + responseData.CHECKOUT_DATE + '</th></tr><tr><td>Checkout Time</td><th>' + responseData.CHECKOUT_TIME + '</th></tr><tr><td>Co Person Email 1</td><th>' + responseData.CO_PERSON_EMAIL_1 + '</th></tr><tr><td>Co Person Email 2</td><th>' + responseData.CO_PERSON_EMAIL_2 + '</th></tr><tr><td>Content Source</td><th>' + responseData.CONTENT_SOURCE + '</th></tr><tr><td>Subject</td><th>' + responseData.SUBJECT + '</th></tr><tr><td>Topic</td><th>' + responseData.TOPIC + '</th></tr></tbody></table>';
                        // var modalbody = modalBlock.children("div.modal-dialog").children("div.modal-content").children("div.modal-body");
                        //modalbody.html(_content);
                        $("#event_details_Div").html(_content);
                    }
                    else {
                        $("#event_details_Div").html(null);


                    }
                }
                else
                {
                    $("#event_details_Div").html(null);
                }

                //**************************
                //if (data.status) {
                //    var responseData = data.response[0];
                //    var _content = '<table class="table table-responsive"><tbody><tr><td>Full Name</td><th>' + responseData.NAME + '</th></tr><tr><td>Registration Start Date</td><th>' + responseData.REG_START_DATE + '</th></tr><tr><td>Registration End Date</td><th>' + responseData.REG_END_DATE + '</th></tr><tr><td>Status</td><th>' + responseData.STATUS + '</th></tr><tr><td>Message</td><th>' + responseData.MESSAGE + '</th></tr><tr><td>Person number</td><th>' + responseData.PERSON_NO + '</th></tr><tr><td>Comment</td><th>' + responseData.COMMENT + '</th></tr><tr><td>Class Val</td><th>' + responseData.CLASS_VAL + '</th></tr><tr><td>Checking Date</td><th>' + responseData.CHECKIN_DATE + '</th></tr><tr><td>Checking Time</td><th>' + responseData.CHECKIN_TIME + '</th></tr><tr><td>Checkout Date</td><th>' + responseData.CHECKOUT_DATE + '</th></tr><tr><td>Checkout Time</td><th>' + responseData.CHECKOUT_TIME + '</th></tr><tr><td>Co Person Email 1</td><th>' + responseData.CO_PERSON_EMAIL_1 + '</th></tr><tr><td>Co Person Email 2</td><th>' + responseData.CO_PERSON_EMAIL_2 + '</th></tr><tr><td>Content Source</td><th>' + responseData.CONTENT_SOURCE + '</th></tr><tr><td>Subject</td><th>' + responseData.SUBJECT + '</th></tr><tr><td>Topic</td><th>' + responseData.TOPIC + '</th></tr></tbody></table>';
                //   // var modalbody = modalBlock.children("div.modal-dialog").children("div.modal-content").children("div.modal-body");
                //    //modalbody.html(_content);
                //    $("#event_details_Div").html(_content);
                   
                //}


                //************************

            }
        });
        //alert(event_id_);

    });
    //user/update-bp
    //update_bp_frm
    //btn_save_bp
    $(document).on("click", "#btn_save_bp", function () {
        // var formdata = $.formdata("#update_bp_frm");
        var hide_user_id = $("#hide_user_id").val();
        var bp_dd = $("#bp_dd option:selected").val();
        
        var formArray = {};
        formArray["hide_user_id"] = hide_user_id;
        formArray["bp_dd"] = bp_dd;
        $.ajax({
            type: 'POST',
            url: _BaseURL + '/user/update-bp',
            dataType: "json",
            data: formArray,           
            success: function (result)
            {
                alert(result.response);
            }
        });
    });

    $(document).on("click", "#btn_update_bp", function () {
        var $this = $(this);
        var user_id = $this.val();
        $("#hide_user_id").val(user_id);
        var URL = _BaseURL + "/user/user-profile-data/" + user_id
        $.getJSON(URL, function (data) {
            var responseData = data.response[0];
            var bp = responseData.ROLE;
            $("#bp_dd option:selected").text(bp);
            //alert(bp);


        });

    });
    //delete_btn
    $(document).on("click", "#delete_btn", function () {

        var $this = $(this);
        var Record_id = $this.val();
        $("#record_id_hide").val(Record_id);
       
        });
        //btn_delete_ias
    $(document).on("click", "#btn_delete_ias", function () {
        var Record_id=  $("#record_id_hide").val();
            var formArray = {};
            formArray["Record_id"] = Record_id;
            $.ajax({
                type: 'POST',
                url: _BaseURL + '/ias/delete-ias',
                dataType: "json",
                data: formArray,
                success: function (result) {
                    alert(result.response);
                    $.ajax({
                        url: _BaseURL + "/iascoaching/get-ias",
                        type: "POST",
                        async: false,
                        dataType: "json",
                        success: function (data) {
                            $("#div_of_Ias").Gridview(data.response, {
                                autocolumn: false,
                                column: [
                                            //{ name: "RECORD SYS ID", dbcol: "RECORD_SYS_ID" },
                                            { name: "SUBJECT", dbcol: "SUBJECT_NAME" },
                                            { name: "COACHING DATE", dbcol: "COACHING_DATE" },
                                {
                                    name: "Action",
                                    dbcol: "RECORD_SYS_ID",
                                    value: '<button type="button" id="update_btn" class="update_btn btn btn-info" data-toggle="modal" data-target="#myModal3"><i class="fa fa-pencil-square-o" aria-hidden="true"></i></button><button type="button" id="delete_btn" class="update_btn btn btn-info" data-toggle="modal" data-target="#myModal6"><i class="fa fa-trash" aria-hidden="true"></i></button>'
                                }
                                ],

                            });
                        }
                    });
                }
        });


    });
    $(document).on("click", "#updateContent", function () {
        var thisObj = $(this);
        var id = thisObj.data("id");
        $.ajax({
            url: _BaseURL + "/iascoaching/get-subject",
            type: "POST",
            async: false,
            dataType: "json",
            success: function (data) {
                $("#id_of_sub").Dropdown(data.response, {
                    value: {
                        text: "LOV_NAME",
                        value: "LOV_ID"
                    }
                });
            }
        });
        //iascoaching/get-topic
        $.ajax({
            url: _BaseURL + "/iascoaching/get-topic",
            type: "POST",
            async: false,
            dataType: "json",
            success: function (data) {
                $("#id_of_topic").Dropdown(data.response, {
                    value: {
                        text: "LOV_NAME",
                        value: "LOV_ID"
                    }
                });
            }
        });


    });
     
    
});
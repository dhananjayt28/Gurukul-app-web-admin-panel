﻿$(function () {
    "use strict"
    var _BaseURL = window.location.origin;
    var url = "";
    var jsondata = "";
    var jdata = "";
    var statejsondata = "";
    var statejdata = "";
    var country_id = "";
    
    var action_name = !$.isNull($.getactionname()) ? $.getactionname().toLowerCase() : "";
    var changeDateFormat = function (date) {
        //var date = "24/09/1977";
        var datearray = date.split("-");
        //console.log(datearray)

        var newdate = datearray[1] + '-' + datearray[0] + '-' + datearray[2];
        return newdate;
    }
    
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
    $("#startDate").datepicker({
        changeYear: true,
        changeMonth: true,
        //minDate: 0,
        dateFormat: 'dd-mm-yy',
        onSelect: function (selected) {
            selected = changeDateFormat(selected);
            var dt = new Date(selected);
            console.log(dt);
            dt.setDate(dt.getDate());
            console.log(dt);
            $("#endDate").datepicker({
                changeYear: true,
                changeMonth: true,
                minDate: dt,               
                dateFormat: 'dd-mm-yy',               
            });
        }
    });
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
       // minDate: 0,
        dateFormat: 'dd-mm-yy'
    });
    var isValidFileExtension = function (file, filetype) {
        var _isValid = false;
        if (typeof file === "object" && typeof filetype === "object") {
            if (file.files && file.files[0]) {
                var _fileData = file.files[0];
                var _fileName = _fileData.name;
                var _fileSplitArray = _fileName.split(".");
                var _fileExtension = _fileSplitArray[_fileSplitArray.length - 1];
                if ($.inArray(_fileExtension, filetype) != -1) {
                    _isValid = true;
                }
                else {
                    $(file).val("");
                }
            }
        }
        return _isValid;
    }
    $.isValidFile = function (File, Type) {
        return isValidFileExtension(File, Type);
    }
    $(document).on("change", "#itinerary_file", function () {
        
        var bool = $.isValidFile(this, ["pdf"]);
        if (bool !== true) {
            alert("Incorrect File Format, please upload only pdf file");
            $("#itinerary_file").val(null);
        }

    });
    // Using in Event Create Page
    $(document).on("change", "#_event_drpdown", function () {
        var _dropValue = $(this).val();
        var _workshop = $("#GitaAndWorkshop");
        var _gita = $("#GitaDistribute");
        var only_workshop = $("#only_workshop");
        var nivritti = $("#only_nivritti");
        switch (_dropValue) {
            case "1": {
                _workshop.hide();
                _gita.hide();
                only_workshop.hide();
                nivritti.hide();

            } break;
            case "2": {
                _workshop.show();
                _gita.hide();
                only_workshop.show();
                nivritti.show();
            } break;
            case "3": {
                _workshop.show();
                _gita.show();
                only_workshop.hide();
                nivritti.show();
            } break;
            default: {
                _workshop.hide();
                _gita.hide();
                only_workshop.hide();
                nivritti.hide();
            } break;
        }

    });
    //Using in Volunteer Event List
    $(document).on("click", "#showVolunteerProfile", function (e) {
        var thisObj = $(this);
        var _userId = thisObj.data("id");
        var modalBlock = $(".common-popup");
        var URL = _BaseURL + "/user/user-profile-individual-data/" + _userId
        $.getJSON(URL, function (data) {            
            if (data.status) {
                if (data.response !== null) {
                    var responseData = data.response[0];
                    var _content = '<table class="table table-responsive"><tbody><tr><td>Full Name</td><th>' + responseData.NAME + '</th></tr><tr><td>Date Of Birth</td><th>' + responseData.DOB + '</th></tr><tr><td>Gender</td><th>' + responseData.GENDER + '</th></tr><tr><td>Mobile No</td><th>' + responseData.MOBILE_NO + '</th></tr><tr><td>E-Mail ID</td><th>' + responseData.EMAIL_ID + '</th></tr><tr><td>Satsang Country</td><th>' + responseData.COUNTRY + '</th></tr><tr><td>Satsang City</td><th>' + responseData.CITY + '</th></tr><tr><td>Satsang Chapter</td><th>' + responseData.SATSANG_CHAPTER + '</th></tr><tr><td>Education</td><th>' + responseData.EDUCATION + '</th></tr></tbody></table>';
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

    var view_master = function () {
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
                                        listname: "TYPE",
                                        sl_id: "SL_ID"
                                    }
                                },
                                 {
                                     name: "Add Sub Category",
                                     value: '<button id="add_sub_category" class="btn btn-info" data-toggle="modal" data-target="#AddSubMasterCategoryModal"><i class="fa fa-plus-square" aria-hidden="true"></i> </button>',
                                     data: {
                                         "catid": "SL_ID",
                                         allow: "DATA_ALLOW"
                                     },

                                 }
                    ],
                    onrowbound: function (elem) {
                        var row = $(elem);
                        var view_divBlock = row.find("a.BtnViewParentMaster");
                        var divBlock = row.find("button#add_sub_category");
                        var catid = divBlock.data("catid");
                        var allow = divBlock.data("allow");
                        if (allow === "N") {
                            divBlock.removeAttr("data-target");
                            divBlock.hide();
                            view_divBlock.attr("data-access", "N");
                        }
                        else {
                            view_divBlock.attr("data-access", "Y");
                        }
                    }
                });
            },
            error: function (errorResponse) {
                if (!errorResponse.response) {
                    errorResponse.response = "network error occurred";
                }
                $.msgbox(errorResponse.response, "error");
            }
        });
    }
    view_master();
        var view_category_list = function () {
            var hidden_category_name = $("#category_name_hidden").val();
            var data_access =  $("#data_access_hidden").val();
            var formArray = {};
            formArray["category_name"] = hidden_category_name;
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
                        autocolumn: false,
                        column: [
                                    { name: "CATEGORY LIST ID", dbcol: "LOV_ID" },
                                    { name: "CATEGORY LIST", dbcol: "LOV_NAME" },
                        {
                            name: "Delete",
                            value: '<button id="delete_sub_category" class="" data-toggle="modal" data-target="#DeleteSubMasterCategoryModal"><i class="fa fa-trash" aria-hidden="true"></i> </button>',
                            data: {
                                "LOV_ID": "LOV_ID",
                            },

                        }
                        ],
                        onrowbound: function (elem)
                        {                            
                            var row = $(elem);
                            var deletedivBlock = row.find("button#delete_sub_category");
                         
                            if (data_access === "N")
                            {                             
                               
                                deletedivBlock.hide();
                                deletedivBlock.removeAttr("data-target");
                                
                            }
                        },
                        class: "table table-responsive table-bordered",
                        id: "tableGrid"
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
        }
        /***************************************
           * Title - Load Gridview of ParentMaster
           * Parameter -null
           * Return - gridview
           * Syntax - null
           ***************************************/
        $(document).on("click", ".BtnViewParentMaster", function () {
            var category_id = $(this).data("sl_id");
            var data_access = $(this).data("access");          
            $("#category_id_hidden").val(category_id);
            $("#data_access_hidden").val(data_access);
            var category_name = $(this).data("listname");
            $("#category_name_hidden").val(category_name);
            var $this = $(this);
            view_category_list();
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
                    view_master();
                    
                },
                error: function (errorThrown) {
                    $.msgbox(errorThrown.responseJSON.response, "error");
                }
            });
        });
        $(document).on("click", "#add_sub_category", function () {
            var $this = $(this);
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
                        value: "LOV_CODE"
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
       var EventState = $("#EventStateId option:selected").val();
       var EventLocation = $("#EventLocationId option:selected").val();
       var hoidayDate = $("#hoidayDate").val();
       var hoidayEndDate = $("#hoidayEndDate").val();
       var Message_to_user = $("#Message_to_user").val();
        //console.log(start_date);
       var event_type = $("#_event_drpdown").val();
      
       if (event_type === "" || event_type === "0")
       {
           alert("Please select Event type");
           //$.redirect(_BaseURL + "/event/event-add");
           return false;
       }
       var base = "";
       if (event_type === "1")
       {
           
           if (male_no === "" || female_no===""||parseInt(male_no) <= 0 || parseInt(female_no) <= 0 || start_date === "" || end_date === "" )
           {
               if (parseInt(male_no) <= 0 || parseInt(female_no) <= 0 || male_no === "" || female_no==="")
               {
                base = "Plesae enter male and female req no more than 0";
                      
               }
               if (start_date === "")
               {
                   base = base + "\nPlease Enter Start Date";
               }
               if (end_date === "") {
                   base = base + "\nPlease Enter End Date";
               }
             
               alert(base);
              // $.redirect(_BaseURL + "/event/event-add");
               return false;
           }
       }
       if (event_type === "2")
       {
           if (male_no === "" || female_no===""||parseInt(male_no) <= 0 || parseInt(female_no) <= 0 || start_date === "" || end_date === "" || expiry_date === "" || EventState === "0" || hoidayDate===""||hoidayEndDate==="") {

               if (parseInt(male_no) <= 0 || parseInt(female_no) <= 0 || male_no === "" || female_no === "")
               {
                   base = "Plesae enter male and female req no more than 0";
                      
               }
               if (start_date === "")
               {
                   base = base + "\nPlease Enter Start Date";
               }
               if (end_date === "") {
                   base = base + "\nPlease Enter End Date";
               }
               if (expiry_date === "") {
                   base = base + "\nPlease Enter Expiry Date";
               }
               if (EventState === "0") {
                   base = base + "\nPlease Choose State";
               }               
               if (hoidayDate === "" ) {
                   base = base + "\nPlease Enter Holiday Start Date";
               }
               if (hoidayEndDate === "")
               {
                   base = base + "\nPlease Enter Holiday End Date";
               }
               alert(base);
              // $.redirect(_BaseURL + "/event/event-add");
               return false;
           }               
       }       
       if (event_type === "3")
       {
           if (male_no === "" || female_no===""||parseInt(male_no) <= 0 || parseInt(female_no) <= 0 || start_date === "" || end_date === "" || expiry_date === "" || EventState === "0" || EventLocation==="0"||Message_to_user==="") {
               if (parseInt(male_no) <= 0 || parseInt(female_no) <= 0 || male_no === "" || female_no === "")
               {
                   base = "Plesae enter male and female req no more than 0";
                      
               }
               if (start_date === "")
               {
                   base = base + "\nPlease Enter Start Date";
               }
               if (end_date === "") {
                   base = base + "\nPlease Enter End Date";
               }
               if (expiry_date === "") {
                   base = base + "\nPlease Enter Expiry Date";
               }
               if (EventState === "0") {
                   base = base + "\nPlease Choose State";
               }               
               
               if (EventLocation === "0" ) {
                   base = base + "\nPlease Select Event Location";
               }
               if (Message_to_user === "") {
                   base = base + "\nPlease Enter Message to User";
               }
               alert(base);
              // $.redirect(_BaseURL + "/event/event-add");
               return false;
                       
           }
       }
       var formdata = $.formdata("#Event_Form");
       $.ajax({
           url: _BaseURL + "/event/event-add",
           type: "POST",
           async: false,
           dataType: "json",
           data: formdata,
           processData: false,
           contentType: false,
           success: function (data) {
               alert(data.response);
               $.redirect(_BaseURL + "/event/event-list");
           }
       });

    });
    //raju
    $(document).on("change", "#EventStateId", function () {
        var State_id = $("#EventStateId option:selected").val();
        $.ajax({
            url: _BaseURL + "/event/get-location-name/" + State_id,
            type: "GET",
            async: false,
            dataType: "json",
            processData: false,
            contentType: false,
                success: function (data) {
                    if (data.status) {
                        $("#EventLocationId").Dropdown(data.response, {
                            value: {
                                text: "LOCATION_NAME",
                                value: "LOCATION_SYS_ID"
                            }
                        });
                    } else {
                        $.alert({ title: "Info", content: data.response, type: "orange" });

                    }
                },
        });
    });
    
    //raju
    //add_ias
    $(document).on("click", "#btn_save", function () {
        var sub_ = $("#subject option:selected").text();
       var date_ = $("#iasMainDate").val();
        //Select Subject
       //alert(sub_);
        //alert(date_);
       if (sub_ === "Select" || date_ === "") {
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
                //var ustatus = getUrlParameter('ustatus');
                //if (!$.isNull(ustatus))
                //{
                //    $("#dd_status option:selected").text(ustatus);
                //}
                var ustatus = getUrlParameter('ustatusv');
                if (!$.isNull(ustatus)) {
                    $("#dd_status").val(ustatus);
                }
            }
        });

        $(document).on("change", "#dd_status", function () {
            var user_status = $("#dd_status option:selected").text();
            var user_status_val = $("#dd_status").val();
            //var formArray = {};
            //formArray["user_status"] = user_status;
            $.redirect(_BaseURL + "/user/user-list?ustatus=" + user_status+"&ustatusv="+user_status_val);
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
    if (action_name === "volunteer-event-reg-list") {
      
        $(document).on("change", "#dd_type", function () {
            $("#dd_statuses option:selected").text("Select Status");

        });
        //dd_status
        $.ajax({
            url: _BaseURL + "/event/get-event-status",
            type: "POST",
            async: false,
            dataType: "json",
            success: function (data) {
                $("#dd_statuses").Dropdown(data.response, {
                    value: {
                        text: "LOV_NAME",
                        value: "LOV_ID"
                    }
                });
                var vstatus = getUrlParameter('vstatus');
                if (!$.isNull(vstatus)) {
                    $("#dd_statuses option:selected").text(vstatus);
                }
            }
        });
        //event/get-event-type
        $.ajax({
            url: _BaseURL + "/event/get-event-type",
            type: "POST",
            async: false,
            dataType: "json",
            success: function (data) {
                $("#dd_type").Dropdown(data.response, {
                    value: {
                        text: "LOV_NAME",
                        value: "LOV_ID"
                    }
                });
                var etype = getUrlParameter('etype');
                if (!$.isNull(etype)) {
                    $("#dd_type option:selected").text(etype);
                }
            }
        });
        $(document).on("change", "#dd_statuses", function () {
            var volunteer_status = $("#dd_statuses option:selected").text();
            var event_type = $("#dd_type option:selected").text();
            //alert(volunteer_status);
            //var formArray = {};
            //formArray["user_status"] = user_status;
            $.redirect(_BaseURL + "/event/volunteer-event-reg-list?vstatus=" + volunteer_status + "&etype=" + event_type);
            
        });
    }
    $(document).on("click", ".showEventDetails", function () {
        var event_type_ = $("#dd_type option:selected").text();
        if (event_type_ === "Nivritti Gurukul")
        {
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
                    if (data.status === "true") {
                        if (data.response != null) {
                            console.log(data.response);
                            var responseData = data.response[0];
                            var event_type = responseData.EVENT_TYPE;
                            console.log(event_type);
                            var _content = '<table class="table table-responsive"><tbody><tr><td>Event Type</td><th>' + responseData.EVENT_TYPE + '</th></tr><tr><td>Event Name</td><th>' + responseData.EVENT_NAME + '</th></tr><tr><td>Event Start Date</td><th>' + responseData.EVENT_START_DATE + '</th></tr><tr><td>Event End Date</td><th>' + responseData.EVENT_END_DATE + '</th></tr><tr><td>Full Name</td><th>' + responseData.NAME + '</th></tr><tr><td>Registration Start Date</td><th>' + responseData.REG_START_DATE + '</th></tr><tr><td>Registration End Date</td><th>' + responseData.REG_END_DATE + '</th></tr><tr><td>Status</td><th>' + responseData.STATUS + '</th></tr><tr><td>Message</td><th>' + responseData.MESSAGE + '</th></tr><tr><td>Note</td><th>' + responseData.NOTES + '</th></tr></tbody></table>';
                            //var _content = '<table class="table table-responsive"><tbody><tr><td>Event Name(Start Date-End Date)</td><th>' + responseData.EVENT_NAME + '(' + responseData.EVENT_START_DATE + '-' + responseData.EVENT_END_DATE + ')' + '</th></tr><tr><td>Full Name</td><th>' + responseData.NAME + '</th></tr><tr><td>Registration Start Date</td><th>' + responseData.REG_START_DATE + '</th></tr><tr><td>Registration End Date</td><th>' + responseData.REG_END_DATE + '</th></tr><tr><td>Status</td><th>' + responseData.STATUS + '</th></tr><tr><td>Message</td><th>' + responseData.MESSAGE + '</th></tr><tr><td>Person number</td><th>' + responseData.PERSON_NO + '</th></tr><tr><td>Comment</td><th>' + responseData.COMMENT + '</th></tr><tr><td>Class Val</td><th>' + responseData.CLASS_VAL + '</th></tr><tr><td>Checking Date</td><th>' + responseData.CHECKIN_DATE + '</th></tr><tr><td>Checking Time</td><th>' + responseData.CHECKIN_TIME + '</th></tr><tr><td>Checkout Date</td><th>' + responseData.CHECKOUT_DATE + '</th></tr><tr><td>Checkout Time</td><th>' + responseData.CHECKOUT_TIME + '</th></tr><tr><td>Co Person Email 1</td><th>' + responseData.CO_PERSON_EMAIL_1 + '</th></tr><tr><td>Co Person Email 2</td><th>' + responseData.CO_PERSON_EMAIL_2 + '</th></tr></tbody></table>';
                            $("#event_details_Div").html(_content);
                        }
                        else {
                            $("#event_details_Div").html(null);
                        }
                    }
                    else {
                        $("#event_details_Div").html(null);
                    }
                }
            });

        }
        if (event_type_ === "Workshop") {
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
                    if (data.status === "true") {
                        if (data.response != null) {
                            console.log(data.response);
                            var responseData = data.response[0];
                            var event_type = responseData.EVENT_TYPE;
                            console.log(event_type);
                            var _content = '<table class="table table-responsive"><tbody><tr><td>Event Type</td><th>' + responseData.EVENT_TYPE + '</th></tr><tr><td>Event Name</td><th>' + responseData.EVENT_NAME + '</th></tr><tr><td>Event Start Date</td><th>' + responseData.EVENT_START_DATE + '</th></tr><tr><td>Event End Date</td><th>' + responseData.EVENT_END_DATE + '</th></tr><tr><td>Full Name</td><th>' + responseData.NAME + '</th></tr><tr><td>Registration Start Date</td><th>' + responseData.REG_START_DATE + '</th></tr><tr><td>Registration End Date</td><th>' + responseData.REG_END_DATE + '</th></tr><tr><td>Origin Place</td><th>' + responseData.ORIGIN_PLACE + '</th></tr><tr><td>Destination Place</td><th>' + responseData.DESTINATION_PALACE + '</th></tr><tr><td>Transport mode origin</td><th>' + responseData.TRANSPORT_MODE_ORIGIN + '</th></tr><tr><td>Origin Location</td><th>' + responseData.ORIGIN_LOCATION + '</th></tr><tr><td>Transport Mode End</td><th>' + responseData.TRANSPORT_MODE_END + '</th></tr><tr><td>End Location</td><th>' + responseData.END_LOCATION + '</th></tr><tr><td>Status</td><th>' + responseData.STATUS + '</th></tr><tr><td>Message</td><th>' + responseData.MESSAGE + '</th></tr><tr><td>Note</td><th>' + responseData.NOTES + '</th></tr><tr><td>Comment For Approver</td><th>' + responseData.COMMENT_FOR_APPROVER + '</th></tr></tbody></table>';
                          //  var _content = '<table class="table table-responsive"><tbody><tr><td>Event Name(Start Date-End Date)</td><th>' + responseData.EVENT_NAME + '(' + responseData.EVENT_START_DATE + '-' + responseData.EVENT_END_DATE + ')' + '</th></tr><tr><td>Full Name</td><th>' + responseData.NAME + '</th></tr><tr><td>Registration Start Date</td><th>' + responseData.REG_START_DATE + '</th></tr><tr><td>Registration End Date</td><th>' + responseData.REG_END_DATE + '</th></tr><tr><td>Status</td><th>' + responseData.STATUS + '</th></tr><tr><td>Message</td><th>' + responseData.MESSAGE + '</th></tr><tr><td>Person number</td><th>' + responseData.PERSON_NO + '</th></tr><tr><td>Comment</td><th>' + responseData.COMMENT + '</th></tr><tr><td>Class Val</td><th>' + responseData.CLASS_VAL + '</th></tr><tr><td>Checking Date</td><th>' + responseData.CHECKIN_DATE + '</th></tr><tr><td>Checking Time</td><th>' + responseData.CHECKIN_TIME + '</th></tr><tr><td>Checkout Date</td><th>' + responseData.CHECKOUT_DATE + '</th></tr><tr><td>Checkout Time</td><th>' + responseData.CHECKOUT_TIME + '</th></tr><tr><td>Co Person Email 1</td><th>' + responseData.CO_PERSON_EMAIL_1 + '</th></tr><tr><td>Co Person Email 2</td><th>' + responseData.CO_PERSON_EMAIL_2 + '</th></tr></tbody></table>';
                            $("#event_details_Div").html(_content);
                        }
                        else {
                            $("#event_details_Div").html(null);
                        }
                    }
                    else {
                        $("#event_details_Div").html(null);
                    }
                }
            });

        }
        if (event_type_ === "Gita Distribution")
        {
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
                    if (data.status === "true") {
                        if (data.response != null) {
                            console.log(data.response);
                            var responseData = data.response[0];
                            var event_type = responseData.EVENT_TYPE;
                            console.log(event_type);
                            var _content = '<table class="table table-responsive"><tbody><tr><td>Event Type</td><th>' + responseData.EVENT_TYPE + '</th></tr><tr><td>Event Name</td><th>' + responseData.EVENT_NAME + '</th></tr><tr><td>Event Start Date</td><th>' + responseData.EVENT_START_DATE + '</th></tr><tr><td>Event End Date</td><th>' + responseData.EVENT_END_DATE + '</th></tr><tr><td>Full Name</td><th>' + responseData.NAME + '</th></tr><tr><td>Registration Start Date</td><th>' + responseData.REG_START_DATE + '</th></tr><tr><td>Registration End Date</td><th>' + responseData.REG_END_DATE + '</th></tr><tr><td>Transportaion Arrangement Required</td><th>' + responseData.TRANSPORTAION_ARRANGEMENT_REQUIRED + '</th></tr><tr><td>Accomodation Arrangement Required</td><th>' + responseData.ACCOMODATION_ARRANGEMENT_REQUIRED + '</th></tr><tr><td>Card Type</td><th>' + responseData.CARD_TYPE + '</th></tr><tr><td>Status</td><th>' + responseData.STATUS + '</th></tr><tr><td>Message</td><th>' + responseData.MESSAGE + '</th></tr><tr><td>Note</td><th>' + responseData.NOTES + '</th></tr></tbody></table>';
                            //var _content = '<table class="table table-responsive"><tbody><tr><td>Event Name(Start Date-End Date)</td><th>' + responseData.EVENT_NAME + '(' + responseData.EVENT_START_DATE + '-' + responseData.EVENT_END_DATE + ')' + '</th></tr><tr><td>Full Name</td><th>' + responseData.NAME + '</th></tr><tr><td>Registration Start Date</td><th>' + responseData.REG_START_DATE + '</th></tr><tr><td>Registration End Date</td><th>' + responseData.REG_END_DATE + '</th></tr><tr><td>Status</td><th>' + responseData.STATUS + '</th></tr><tr><td>Message</td><th>' + responseData.MESSAGE + '</th></tr><tr><td>Person number</td><th>' + responseData.PERSON_NO + '</th></tr><tr><td>Comment</td><th>' + responseData.COMMENT + '</th></tr><tr><td>Class Val</td><th>' + responseData.CLASS_VAL + '</th></tr><tr><td>Checking Date</td><th>' + responseData.CHECKIN_DATE + '</th></tr><tr><td>Checking Time</td><th>' + responseData.CHECKIN_TIME + '</th></tr><tr><td>Checkout Date</td><th>' + responseData.CHECKOUT_DATE + '</th></tr><tr><td>Checkout Time</td><th>' + responseData.CHECKOUT_TIME + '</th></tr><tr><td>Co Person Email 1</td><th>' + responseData.CO_PERSON_EMAIL_1 + '</th></tr><tr><td>Co Person Email 2</td><th>' + responseData.CO_PERSON_EMAIL_2 + '</th></tr></tbody></table>';
                            $("#event_details_Div").html(_content);
                        }
                        else {
                            $("#event_details_Div").html(null);
                        }
                    }
                    else {
                        $("#event_details_Div").html(null);
                    }
                }
            });

        }
        //var $this = $(this);
        //var event_id_ = $this.data("id");
        //var formArray = {};
        //formArray["event_id_"] = event_id_;
        //$.ajax({
        //    url: _BaseURL + "/event/get-event",
        //    type: "POST",
        //    async: false,
        //    dataType: "json",
        //    data: formArray,
        //    success: function (data) {
        //        //************************************
        //        if (data.status==="true") {
        //            if (data.response != null) {
        //                console.log(data.response);
        //                var responseData = data.response[0];
        //                var event_type = responseData.EVENT_TYPE;
        //                console.log(event_type);
        //                var _content = '<table class="table table-responsive"><tbody><tr><td>Event Name(Start Date-End Date)</td><th>' + responseData.EVENT_NAME +'('+ responseData.EVENT_START_DATE+'-'+responseData.EVENT_END_DATE+')'+'</th></tr><tr><td>Full Name</td><th>' + responseData.NAME + '</th></tr><tr><td>Registration Start Date</td><th>' + responseData.REG_START_DATE + '</th></tr><tr><td>Registration End Date</td><th>' + responseData.REG_END_DATE + '</th></tr><tr><td>Status</td><th>' + responseData.STATUS + '</th></tr><tr><td>Message</td><th>' + responseData.MESSAGE + '</th></tr><tr><td>Person number</td><th>' + responseData.PERSON_NO + '</th></tr><tr><td>Comment</td><th>' + responseData.COMMENT + '</th></tr><tr><td>Class Val</td><th>' + responseData.CLASS_VAL + '</th></tr><tr><td>Checking Date</td><th>' + responseData.CHECKIN_DATE + '</th></tr><tr><td>Checking Time</td><th>' + responseData.CHECKIN_TIME + '</th></tr><tr><td>Checkout Date</td><th>' + responseData.CHECKOUT_DATE + '</th></tr><tr><td>Checkout Time</td><th>' + responseData.CHECKOUT_TIME + '</th></tr><tr><td>Co Person Email 1</td><th>' + responseData.CO_PERSON_EMAIL_1 + '</th></tr><tr><td>Co Person Email 2</td><th>' + responseData.CO_PERSON_EMAIL_2 + '</th></tr></tbody></table>';
        //                $("#event_details_Div").html(_content);
        //            }
        //            else {
        //                $("#event_details_Div").html(null);
        //            }
        //        }
        //        else
        //        {
        //            $("#event_details_Div").html(null);
        //        }
        //    }
        //});

        //here
        $.ajax({
            url: _BaseURL + "/event/get-content",
            type: "POST",
            async: false,
            dataType: "json",
            data: formArray,
            success: function (data) {
                $("#content_div").Gridview(data.response, {
                    autocolumn: false,
                    column: [
                                { name: "CONTENT SOURCE", dbcol: "CONTENT_SOURCE" },
                                { name: "SUBJECT", dbcol: "SUBJECT" },
                                 { name: "TOPIC", dbcol: "TOPIC" }
                    ],

                });
            }
        });
       

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
                var ddlvalue = $("#dd_status option:selected").text();
                if (ddlvalue === "Approved"){
                    $.redirect(_BaseURL + "/user/user-list?ustatus=Approved&ustatusv=101");
                }
                if (ddlvalue === "Deleted") {
                    $.redirect(_BaseURL + "/user/user-list?ustatus=Deleted&ustatusv=104");
                }
                if (ddlvalue === "Rejected") {
                    $.redirect(_BaseURL + "/user/user-list?ustatus=Rejected&ustatusv=102");
                }
                if (ddlvalue === "Blocked") {
                    $.redirect(_BaseURL + "/user/user-list?ustatus=Blocked&ustatusv=103");
                }
                if (ddlvalue === "Waiting For Approval") {
                    $.redirect(_BaseURL + "/user/user-list?ustatus=Waiting%20For%20Approval&ustatusv=100");
                }
                if (ddlvalue === "Select") {
                    $.redirect(_BaseURL + "/user/user-list");
                }


                
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
            console.log(responseData);
            var bp = responseData.ROLE;
            var bp_id = responseData.ROLE_ID;

            $("#bp_dd").val(bp_id);

            //$("#bp_dd option:selected").text(bp);
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
                                id: "",


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

        $("#event_reg_id_hide").val(id);



    });
    $(document).on("click", "#btn_save_topic_content", function () {
        var event_reg_id_hide = $("#event_reg_id_hide").val();
        var id_of_sub = $("#id_of_sub option:selected").val();
        var id_of_topic = $("#id_of_topic option:selected").val();
        var content_id = $("#content_id").val();
        if (id_of_sub === "0" || id_of_topic==="0" || content_id === "") {
            alert("Please fill all the value");
            return false;
        }
        $.redirect(_BaseURL + "/event/add-topic-event?enent_reg_id=" + event_reg_id_hide + "&subject_id=" + id_of_sub + "&topic_id=" + id_of_topic + "&content=" + content_id);

    });
    $(document).on("click", "#rejectBtn", function () {
        var thisObj = $(this);
        url = thisObj.data("url");
        $.ajax({
            url: _BaseURL + "/event/get-reason",
            type: "POST",
            async: false,
            dataType: "json",
            success: function (data) {
                $("#message_dd").Dropdown(data.response, {
                    value: {
                        text: "LOV_NAME",
                        value: "LOV_ID"
                    }
                });
            }
        });
    });
    $(document).on("click", "#btn_reject_with_msg", function () {
        var msg_id = $("#message_dd option:selected").val();
        var full_url = _BaseURL +"/"+ url + "/" + msg_id
       // alert(full_url);
        $.redirect(full_url);

    });
    $(document).on("click", "#sv_file", function () {
        
        var formdata = $.formdata("#form_sv_itinerary");
        //formdata.append("Mou_Id", mou_id);
        //formdata.append("USer_Id", user_id);
        $.ajax({
            url: _BaseURL + "/event/upload-itinerary",
            type: 'POST',
            dataType: "json",
            data: formdata,
            processData: false,
            contentType: false,
            cache: false,
            enctype: "multipart/form-data",
            success: function (data) {
                alert(data.response);
            },
            error: function () {
                alert("network error occurred");
            }
        });
    });
    $(document).on("click", "#itienary_", function () {
        var thisObj = $(this);
        var event_reg_id = thisObj.data("id");
        $("#hide_event_reg_id").val(event_reg_id);


    });
    if (action_name === "")
    {
        
        $.ajax({
            url: _BaseURL + "/event/get-user-count",
            type: "POST",
            async: false,
            dataType: "json",
            success: function (data) {
                $("#user_count_div").Gridview(data.response, {
                    autocolumn: false,
                    column: [
                       {
                           name: "Item Description",
                           dbcol:"DETAILS"
                       },
                       {
                           name: "Count",
                           dbcol: "COUNT"
                       },

                    ],
                    class: "table table-responsive table-bordered",
                    //id: "view_Table"
                });
            }
        });
        $.ajax({
            url: _BaseURL + "/event/get-event-count",
            type: "POST",
            async: false,
            dataType: "json",
            success: function (data) {
                $("#event_count_div").Gridview(data.response, {
                    autocolumn: false,
                    column: [
                       {
                           name: "Item Description",
                           dbcol: "DETAILS"
                       },
                       {
                           name: "Count",
                           dbcol: "COUNT"
                       },

                    ],
                    //class: "",
                    //id: "view_Table"
                });
            }
        });
    }
    //******************************************************
    /**********************Country AutoComplete***********************/
    $.ajax({
        url: _BaseURL + "/event/get-country-list",
        type: "POST",
        async: false,
        dataType: "json",
        success: function (data) {
            jsondata = data;
            console.log(jsondata);
        }
    });
    var $suggestionList = $("#countryItemList");
    if (jsondata.status) {
        $suggestionList.html("");
        $.each(jsondata.response, function (key, val) {
            var option = $("<option></option>").attr("data-value", val.LOV_ID).text(val.LOV_NAME);
            $suggestionList.append(option);
        });

    }
    $(document).on("input", "#txt_country", function (e) {
        var $this = $(this);
        var itemval = $this.val().trim();
        console.log(itemval)
        var itemid = -1;
        //var $DeliverableJson = $("#deliverableItemJson").html();
        //var $unitBox = $("#deliverableUnit");
        //var $unitTxtBox = $("input[name=unitid]");

        var $datalist = $("datalist#countryItemList option");
        $($datalist).each(function () {
            var _this = $(this);
            var _thisval = _this.val();
            if (_thisval === itemval) {
                itemid = _this.attr("data-value").trim();
            }
        });
        console.log(itemid)
        $.ajax({
            url: _BaseURL + "/event/get-country-list",
            type: "POST",
            async: false,
            dataType: "json",
            success: function (data) {
                jdata = data;
                console.log(jdata);
            }
        });



        // $DeliverableJson = JSON.parse($DeliverableJson);
        $.each(jdata.response, function (key, val) {
            var id = val.LOV_ID;
            if (parseInt(id) === parseInt(itemid)) {
                var name = val.LOV_NAME;
                var unit = val.LOV_ID;
                $this.val(name);
                //$unitBox.val(unit);
                //$unitTxtBox.val(id);
            }
        });

    });
    /* Clean Value  */
    $(document).on("focusout", "#txt_country", function (e) {
        var $this = $(this);
        //var $unitBox = $("#deliverableUnit");
        //var $unitTxtBox = $("input[name=unitid]");
        var itemval = $this.val();
        var itemid = 0;
        var $datalist = $("datalist#countryItemList option");
        $($datalist).each(function () {
            var _this = $(this);
            var _thisval = _this.val();
            //console.log(itemval);
            //console.log(_thisval);
            if (_thisval.trim().toLowerCase() === itemval.trim().toLowerCase()) {
                itemid = _this.attr("data-value").trim();
                country_id = itemid;
            }
        });
        $("#country_id_hide").val(itemid);
        //if (parseInt(itemid) <= 0) {
        //    //$this.val("");
        //    //$unitBox.val("");
        //    //$unitTxtBox.val(-1);
        //    $("#hide_outcome_id").val(itemid);
        //    console.log(itemid);
        //}
        //************************************City autocomplete**********************************
        $.ajax({
            url: _BaseURL + "/event/get-city-list/" + country_id,
            type: "POST",
            async: false,
            dataType: "json",
            success: function (data) {
                statejsondata = data;
            }
        });
        var $suggestionList = $("#stateItemList");
        if (statejsondata.status) {
            $suggestionList.html("");
            $.each(statejsondata.response, function (key, val) {               
                var option = $("<option></option>").attr("data-value", val.LOV_ID).text(val.LOV_NAME);
                $suggestionList.append(option);
            });

        }
        $(document).on("input", "#txt_state", function (e) {
            var $this = $(this);

            var itemval = $this.val().trim();
            // alert(itemval);
            console.log(itemval)
            var itemid = -1;
            //var $DeliverableJson = $("#deliverableItemJson").html();
            //var $unitBox = $("#deliverableUnit");
            //var $unitTxtBox = $("input[name=unitid]");

            var $datalist = $("datalist#stateItemList option");
            $($datalist).each(function () {
                var _this = $(this);
                var _thisval = _this.val();
                if (_thisval === itemval) {
                    itemid = _this.attr("data-value").trim();
                   

                }
            });
            console.log(itemid)
            $.ajax({
                url: _BaseURL + "/event/get-city-list/" + country_id,
                type: "POST",
                async: false,
                dataType: "json",
                success: function (data) {
                    statejdata = data;
                    console.log(statejdata);
                }
            });
            // $DeliverableJson = JSON.parse($DeliverableJson);
            $.each(statejdata.response, function (key, val) {
                var id = val.LOV_ID;
                if (parseInt(id) === parseInt(itemid)) {
                    var name = val.LOV_NAME;
                    var unit = val.LOV_ID;
                    $this.val(name);
                    //$unitBox.val(unit);
                    //$unitTxtBox.val(id);
                }
            });

        });
        $(document).on("focusout", "#txt_state", function (e) {
            var $this = $(this);
            //var $unitBox = $("#deliverableUnit");
            //var $unitTxtBox = $("input[name=unitid]");
            var itemval = $this.val();
            var itemid = 0;
            var $datalist = $("datalist#stateItemList option");
            $($datalist).each(function () {
                var _this = $(this);
                var _thisval = _this.val();
                //console.log(itemval);
                //console.log(_thisval);
                if (_thisval.trim().toLowerCase() === itemval.trim().toLowerCase()) {
                    itemid = _this.attr("data-value").trim();
                    
                }
            });
           
            $("#state_id_hide").val(itemid);
        });
    });
    /**********************************Report****************************************/

    //view summary report
    if (action_name === "daily-summary-report") {
        $(document).on("click", "#search_summary_report", function () {
            var from_date = $("#from_date").val();
            var to_date = $("#to_date").val();
            if (from_date === "" || to_date === "") {
                alert("Please put from date and to date");
                return false;
            }
            $.ajax({
                url: _BaseURL + "/event/get-summary-report?from_date="+from_date+"&to_date="+to_date,
                type: "GET",
                dataType: "json",
                async: false,
                success: function (data) {
                    $("#SummaryReportView").Gridview(data.response, {
                        autocolumn: false,
                        column: [
                            {
                                name: "",
                                value: '<a href="javascript:void(0);" id="ViewDetailedReport" class="ViewDetailedReport" ><i class="fa fa-sort-asc clickable" aria-hidden="true"></i></a>',
                                data: {
                                    date: "Event_Date",
                                    event_name: "Event_Name"
                                }
                                //value:'<button id="view_detailed_report" class="btn"><i class="fa fa-eye">View Detailed Report</i></button>'
                            },
                                    { name: "Event Name", dbcol: "Event_Name" },
                                    { name: "Event Start Date", dbcol: "Event_Start_Date" },
                                    { name: "Event End Date", dbcol: "Event_End_Date" },
                                    { name: "Event Date", dbcol: "Event_Date" },
                                    { name: "Male Required", dbcol: "Male_Required" },
                                    { name: "Female Required", dbcol: "Female_Required" },
                                    { name: "Male Registered", dbcol: "Male_Registered" },
                                    { name: "Female Registered", dbcol: "Female_Registered" },


                        ],
                        class: "table kullaniciTablosu",
                        id: "tableGrid"
                    });
                    $("#tableGrid").DataTable();
                },
                error: function (data) {
                    console.log(data);
                    alert("Oops! Something went wrong...");
                }

            });
        });
        //export_summary_report
        $(document).on("click", "#export_summary_report", function () {
            var from_date = $("#from_date").val();
            var to_date = $("#to_date").val();
            if (from_date === "" || to_date === "") {
                alert("Please put from date and to date");
                return false;
            }
            
            $.redirect(_BaseURL + "/api/excel-export-summary-report?from_date=" + from_date + "&to_date=" + to_date);
               
        });
        var view_detailed_report = function ($this) {
          
            // var $this = $(this);
            var date = $this.data("date");
            var event_name = $this.data("event_name");
            $.ajax({
                //url: API_BASEURL + 'api/get-activity-data?type=Sub Activity&parent_activity_id=' + var_activity_id,
                url: _BaseURL + "/event/get-detailed-report/" + date+"/"+event_name,
                type: "GET",
                async: false,
                dataType: "json",
                success: function (data) {
                   // alert(JSON.stringify(data));
                    var _i_Obj = $this.children("i");
                    var _tr = $this.closest("tr");
                    var _sub_tr = $('<tr class="row1 addactivity-row collapse subActivityData in" aria-expanded="true" style=""></tr>');
                    _sub_tr.append('<td colspan="12"><div id="Gridview_of_Detailed_Report"></div></td>');
                    _sub_tr.children("td");
                    _tr.after(_sub_tr);
                    if (_i_Obj.hasClass("rotate-90")) {
                        $("#Gridview_of_Detailed_Report").Gridview(data.response, {
                            autocolumn: false,
                            column:  [

                                        { name: "Date", dbcol: "DATE" },
                                        { name: "Name", dbcol: "NAME" },
                                        { name: "Gender", dbcol: "GENDER" },
                                        { name: "Pending Application", dbcol: "PENDING_APPLICATION" },
                                        { name: "Approved", dbcol: "APPROVED" },
                                        { name: "Rejected", dbcol: "REJECTED" },
                                         { name: "Cancelled", dbcol: "CANCELLED" },

                            ],
                            class: "table",
                            id: "view_Table"
                        });
                    } else {
                        $(".subActivityData").remove();

                    }


                },
                error: function (errorResponse) {

                    if (!errorResponse.response) {
                        errorResponse.response = "error occurred";
                    }
                  alert("Oops! Something went wrong...")
                }
            });
        }
        /***************************************
            * Title - Load Gridview of Detailed Report 
            * Parameter -null
            * Return - gridview
            * Syntax - null
            ***************************************/
        $(document).on("click", ".ViewDetailedReport", function () {         
            var $this = $(this);
            $this.children("i").toggleClass("rotate-90");
            view_detailed_report($this);
        });
    }
    var view_country = function () {
        $.ajax({
            url: _BaseURL + "/event/get-country-list",
            type: "GET",
            dataType: "json",
            async: false,
            success: function (data) {
                $("#CountryView").Gridview(data.response, {
                    autocolumn: false,
                    column: [

                                { name: "Country Id", dbcol: "LOV_ID" },
                                { name: "Country Name", dbcol: "LOV_NAME" },
                                {
                                    name: "Delete",
                                    value: '<button type="button" id="delete_country" data-toggle="modal" data-target="#delete_country_popup"><i class="fa fa-trash"></i></button>',
                                    data:
                                        {
                                            country_id: "LOV_ID"
                                        }
                                },


                    ],
                    class: "table",
                    id: "table_new"
                });
                $("#table_new").DataTable();
            },
            error: function (data) {
                alert("Oops! Something went wrong")
            }


        });
    }
    if (action_name === "get-country") {
        view_country();        
    }
    var view_city = function () {
        $.ajax({
            url: _BaseURL + "/event/get-city-list",
            type: "GET",
            dataType: "json",
            async: false,
            success: function (data) {
                $("#CityView").Gridview(data.response, {
                    autocolumn: false,
                    column: [

                                { name: "City Id", dbcol: "CITY_ID" },
                                { name: "City Name", dbcol: "CITY_NAME" },
                                 { name: "Country Name", dbcol: "COUNTRY_NAME" },
                                  {
                                      name: "Delete City",
                                      value: '<button type="button" id="delete_city" data-toggle="modal" data-target="#delete_city_popup"><i class="fa fa-trash"></i></button>',
                                      data:{
                                          city_id:"CITY_ID"
                                      }
                                  },


                    ],
                    class: "table",
                    id: "table_city"
                });
                $("#table_city").DataTable();
            },
            error: function (data) {
                alert("Oops! Something went wrong")
            }


        });
    }
    if (action_name === "get-city") {
        view_city();
    }
    $(document).on("click", "#search_approved_report", function () {
        var from_date = $("#from_date_").val();
        var to_date = $("#to_date_").val();
        if (from_date === "" || to_date === "") {
            alert("Please put from date and to date");
            return false;
        }
        $.ajax({
            url: _BaseURL + "/event/get-arrival-depurture-report?from_date=" + from_date + "&to_date=" + to_date,
            type: "GET",
            dataType: "json",
            async: false,
            success: function (data) {
                $("#arrival_report_view").Gridview(data.response, {
                    autocolumn: false,
                    column: [
                        
                                { name: "Name", dbcol: "NAME" },
                                { name: "Gender", dbcol: "GENDER" },
                                { name: "Date of Birth", dbcol: "DOB" },
                                { name: "Arrival Date", dbcol: "ARRIVAL_DATE" },
                                { name: "Arrival Time", dbcol: "ARRIVAL_TIME" },
                                { name: "Depurture Date", dbcol: "DEPARTURE_DATE" },
                                { name: "Deputure Time", dbcol: "DEPARTURE_TIME" },
                                //{ name: "Subjects Volunteers can teach", dbcol: "SUBJECTS_VOLUNTEER_CAN_TEACH" },


                    ],
                    class: "table kullaniciTablosu",
                    id: "tableGrid1"
                });
                $("#tableGrid1").DataTable();
            },
            error: function (data) {
                alert("Oops! Something went wrong...");
            }
        })
    });
    $(document).on("click", "#export_approved_report", function () {
        var from_date = $("#from_date_").val();
        var to_date = $("#to_date_").val();
        if (from_date === "" || to_date === "") {
            alert("Please put from date and to date");
            return false;
        }
        $.redirect(_BaseURL + "/api/excel-export-arrival-depurture-report?from_date=" + from_date + "&to_date=" + to_date);
        
    });
    $.bind_Partner_list = function () {
     
        $.ajax({
            type: 'POST',
            url: _BaseURL + '/event/get-state-list',
            dataType: "json",
            success: function (result) {
                if ($.parseBool(result.status)) {

                    $("#State_list").html("");
                    $.each(result.response, function (index, item) {
                        //To remove select organization
                        if (item.STATE_ID != 0) {
                            var _partnerId = item.STATE_ID;
                            var _orgId = item.STATE_NAME.replace(/ /g, "_");
                            var _orgName = item.STATE_NAME;
                            $("#State_list").append($("<li></li>").html('<label for="' + _orgId + '"><input type="checkbox" class="partnerchecklist" id="' + _orgId + '" value="' + _partnerId + '" data-state="' + _orgName + '" /> ' + _orgName + '</label>'));

                        }
                    });
                }
                else {
                    $('#State_list').val(null);
                }
            },
            error: function (errorThrown) {
                alert(errorThrown.responseJSON.response);
                // $.msgbox(errorThrown.responseJSON.response, "error");
            }
        });

    }
    //dropdown & checkbox list bind
    $(document).on("click", "#state_allocate_", function () {
        var $this = $(this);
        var event_reg_sys_id = $this.data("id");
        $("#event_reg_sys_id_hidden").val(event_reg_sys_id);
        $.bind_Partner_list();
        $.ajax({
            url: _BaseURL + '/event/get-state-list',
            type: "POST",           
            dataType: "json",
            success: function (data) {
                $("#ddl_origin,#ddl_end").Dropdown(data.response, {
                    value: {
                        text: "STATE_NAME",
                        value: "STATE_ID"
                    }
                });
            }
        });
    });
    // save state allocation
    $(document).on("click", "#btn_save_state_allocation", function () {
       // var state_origin = $("#ddl_origin").val();
        var state_origin = $("#ddl_origin option:selected").text();
      //  var state_end = $("#ddl_end").val();
        var state_end = $("#ddl_end option:selected").text();
        var trans_origin = $("#trans_origin_ddl").val();
        var trans_end = $("#trans_end_ddl").val();
        var event_reg_sys_id = $("#event_reg_sys_id_hidden").val();
        var origin_place = $("#origin_place_name").val();
        var destination_place = $("#destination_place_name").val();
      
        var obj = [];
        var error = [];
        var state_list = "{";
        var state_name_list = "{";
        $('ul.checkboxList').find("input:checkbox:checked").each(function (key,val) {
            var state_id = ($(this).val());
            var state_name = ($(this).data("state"));

            if (key !== 0) {
                state_list = state_list + "," + state_id;
                state_name_list = state_name_list + "," + state_name;
            }
            else {
                state_list = state_list + state_id;
                state_name_list = state_name_list  + state_name;
            }
        });
        state_list = state_list + "}"
        state_name_list = state_name_list + "}"
        obj.push({
            EVENT_REG_SYS_ID: event_reg_sys_id,
            ORIGIN_LOCATION: state_origin,
            END_LOCATION: state_end,
            TRANSPORTATION_MODE_ORIGIN: trans_origin,
            TRANSPORTATION_MODE_END: trans_end,
            STATE_ID: state_list,
            STATE_NAME: state_name_list,
            ORIGIN_PLACE: origin_place,
            DESTINATION_PLACE: destination_place
        });
        var state_allocation_list = JSON.stringify(obj);
        if (state_origin === "0" || state_end === "0" || trans_origin === "0" || trans_end === "0" || state_list === "{}" || parseInt(origin_place.length) === 0 || parseInt(destination_place.length) === 0) {

          
            if (state_origin === "0") {
                error.push("Please Select Origin State\n");
            }
            if (state_end === "0") {
                error.push("Please Select End State\n");
            }
            if (trans_origin === "0") {
                error.push("Please Select Transportation Mode of Origin\n");
            }
            if (trans_end === "0") {
                error.push("Plaese Select Transporation Mode of End\n");
            }
            if (state_list === "{}")
            {
                error.push("Plaese Select Atleast One State\n");
            }
            console.log(parseInt(origin_place.length));
            if (parseInt(origin_place.length) === 0) {
                error.push("Plaese put origin place\n");
            }
            if (parseInt(origin_place.length) === 0) {
                error.push("Plaese put destination place\n");
            }

        }
      
        if (error.length > 0) {
            alert(error);
            return false;
        }
        console.log(state_allocation_list);
        var state_allocation_list = escape(state_allocation_list);
        var formArray = {};
        formArray["jsondata"]=state_allocation_list;
        $.ajax({
            url: _BaseURL + "/event/post-state-allocation",
            data:formArray,
            type: "POST",
            dataType: "json",           
           // contentType: 'application/json',
            success: function (data) { 
                alert(data.response);
                if ($.parseBool(data.status)) {
                    $("#state_allocate_popup").modal('hide');
                }
            },
            error: function (data) { 
                console.log(data.errorResponse);
            }
        });
        
     });
    //delete sub category data set
    $(document).on("click", "#delete_sub_category", function () {
        var $this = $(this);
        var lov_id = $(this).data("lov_id");
        $("#delete_sub_category_id").val(lov_id);
        $("#delete_category_id").val($("#category_id_hidden").val());      
    });
    //delete sub category action
    $(document).on("click", "#yes_delete_sub_category", function () {
        var formdata = $.formdata("#Delete_Sub_Category_Form");
        //alert(_BaseURL + "/master/delete-sub-category");
        $.ajax({
            url: _BaseURL + "/master/delete-sub-category",
            type: 'POST',
            dataType: "json",
            data: formdata,
            processData: false,
            contentType: false,
            success: function (result) {
                alert(result.response);
                $("#DeleteSubMasterCategoryModal").modal('hide');
                view_category_list();
            },
            error: function (errorThrown) {
                console.log(errorThrown);
                alert("Oops! Something went wrong...")
            }
        });
    });
    //delete country data set
    $(document).on("click", "#delete_country", function () {
        var $this = $(this);
        var country_id = $this.data("country_id");      
        $("#country_id_hidden").val(country_id);
    });
    //delete country action
    $(document).on("click", "#btn_delete_country", function () {
        var country_id = $("#country_id_hidden").val();
        $.ajax({
            url: _BaseURL + "/event/delete-country?country_id=" + country_id,
            type: "GET",
            dataType: "json",
            success: function (data) {
                alert(data.response);
                if ($.parseBool(data.status)) {
                    view_country();
                    $("#delete_country_popup").modal('hide');
                }
            },
            error: function (data) {
                alert("Oops! Something went wrong");
            }
        })
    });
    //delete city data set
    $(document).on("click", "#delete_city", function () {
        var $this = $(this);
        var city_id = $this.data("city_id");
        $("#city_id_hidden").val(city_id);
    });
    //delete country action
    $(document).on("click", "#btn_delete_city", function () {
        var city_id = $("#city_id_hidden").val();
        $.ajax({
            url: _BaseURL + "/event/delete-city?city_id=" + city_id,
            type: "GET",
            dataType: "json",
            success: function (data) {
                alert(data.response);
                if ($.parseBool(data.status)) {
                    view_city();
                    $("#delete_city_popup").modal('hide');
                }
            },
            error: function (data) {
                alert("Oops! Something went wrong");
            }
        })
    });
    if (action_name === "add-location") {
        $(document).on("click", "#btn_save_location", function () {
            var State_text = $("#EventStateId option:selected").text();
            var location_text = $("#txt_location").val();
            
            if (State_text === "Select State")
            {
                alert("Please Select State Name First...!");
                return false;
            }
            if (location_text === "") {
                alert("Location Name is mandatory");
                return false;
            }
            

            var State_id_ = $("#EventStateId option:selected").val();
            var location_name_ = $("#txt_location").val();
            var formdata = $.formdata("#Location_Form");
            formdata.append("EventManagement.STATE_ID", State_id_);
            formdata.append("LOCATION_NAME",location_name_);
            $.ajax({
                url: _BaseURL + "/event/add-location-master",
                type: "POST",
                async: false,
                dataType: "json",
                data: formdata,
                processData: false,
                contentType: false,
                success: function (data) {
                alert(data.response);
                }
            });
        });
    }
});
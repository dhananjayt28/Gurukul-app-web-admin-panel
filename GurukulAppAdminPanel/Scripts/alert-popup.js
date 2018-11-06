// Alert Popup Using Bootstrap Modal
// Author : Jayanta Rakshit
// Create Date : 14th March 2018
// Requirement :: Bootstrap.min.css & Jquery.min.js both library
// Happy to Use

(function ($) {
    //"Use Strict";
    var bodyContent = "No body content avaiable.";

    $.AlertBox = function (content, option) {

        var _d = {};
        var _o = {};
        // Body Content Data
        _d["body"] = "No body content avaiable.";
        if (!isNULL(content)) {
            if (checkType(content)) {
                switch (getType(content)) {
                    case "object": {
                        var _m = ("message" in content);
                        if (_m) {
                            _d["body"] = content.message;
                        }
                    } break;
                    case "string": {
                        _d["body"] = content;
                    } break;
                }
            }
        }

        // Body Content Data
        
        if (!isNULL(option)) {
            if (checkType(option)) {
                switch (getType(option)) {
                    case "object": {
                        // Check Class
                        var _c = ("class" in option);
                        if (_c) {
                            _d["class"] = option.class;
                        } else {
                            _o["class"] = "common-popup";
                        }

                        // Check title
                        var _c = ("title" in option);
                        if (_c) {
                            _d["title"] = option.title;
                        } else {
                            _o["title"] = "Alert";
                        }



                    } break;                    
                }
            }
        }
        
        

        
        //var _modal = '<div class="modal common-popup" tabindex="-1" role="dialog">
        //                        <div class="modal-dialog" role="document">
        //                            <div class="modal-content">
        //                                <div class="modal-header"><h3>Profile Details</h3></div>
        //                                <div class="modal-body">

        //                                </div>
        //                                <div class="modal-footer">
        //                                    <button type="button" class="btn btn-success"><i class="fa fa-check"></i>Save changes</button>
        //                                    <button type="button" class="btn btn-danger" data-dismiss="modal"><i class="fa fa-times"></i>Close</button>
        //                                </div>
        //                            </div>
        //                        </div>
        //                    </div>';
    }

    // check Parameter Type exists or not
    var checkType = function (c) {
        if (c != null || c != "") {
            var _p = getType(c);
            var _t = ["array", "string", "object", "number"];
            return ($.inArray(_p, _t) > 0) ? true : false;
        }
        else {
            return false;
        }
    };
    // Collect Parameter Type
    var getType = function (c) {
        if (c != null || c != "") {
            return $.type(c).trim().toLowerCase();
        }
        else {
            return "";
        }
    };

    var isNULL = function (c) {
        if (c === null || c === "") {
            return true;
        }
        else {
            return false;
        }
    };
})(jQuery);
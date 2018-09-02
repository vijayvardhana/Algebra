
class Registration {

    constructor(m) {

        this.mType = m.Type;
        this.Location = m.Location;
        this.RefferBy = m.Reffered;
        this.CreatedBy = m.CreatedBy;
        this.IsNew = m.IsNew;

        this.member = {};
        this.spouse = {};
        this.dependent = {};
        this.payment = {};
        this.cheque = {};
        this.ctrl = [];
        this.paymentMode;
        this.url = "/api/member/AddMember";

        this.TabsSelection(this.mType);
    }

    TabsSelection(m) {
        let t = this;
        t.mType = m;
        switch (t.mType) {
            case 1:
            case 5:
                t.RemoveTabs([Tabs.SPO, Tabs.DEP]);
                break;
            case 2:
                t.RemoveTabs([Tabs.DEP]);
                break;
            case 3:
                //All tabs needs to display
                break;
            case 4:
                t.RemoveTabs([Tabs.SPO]);
                break;
        }
    }

    RemoveTabs(tabs) {
        $('.nav-tabs li').each(function (i) {
            let index = $(this).index();
            let value = $(this).find('a:first').attr('aria-controls');
            let _idx = tabs.indexOf(value);
            if (_idx >= 0) {
                $(this).hide();
                let elm = $("#" + value).remove();
            }
        });
    }

    FormControlExtraction() {
        let c = new Array();
        
        $(".form-control").each(function (index) {
            var o = {};
            var id = this.id;
            var value = $(this).val();
            var required = $(this).attr('data-val-required')
                ? true
                : false;

            var errorMessage = $(this).attr('data-val-required');
            var model = $(this).parents(':eq(3)').attr('id');

            var isChequeModel = (model.indexOf("cheque") != -1)
                ? true
                : false;

            if (isChequeModel) {
                o = { 'id': id, 'value': value, 'isRequired': (this.paymentMode === Mode.CHQ || this.paymentMode === Mode.MXM), 'errorMessage': errorMessage, 'model': model, 'isChequeModel': isChequeModel };
            }
            else {
                o = { 'id': id, 'value': value, 'isRequired': required, 'errorMessage': errorMessage, 'model': model, 'isChequeModel': isChequeModel };
            }

            

             console.log(o);
            c[index] = o;
            o = {};
        });
        this.ctrl = c;
    }

    ChequeModelBuilder(cheques) {

        var ids = $('div .cheque').map(function () {
            return this.id
        }).get()

        for (var i = 0; i < ids.length; i++) {
            this.cheque["c" + i] = {
                'Number': this.PropertyValue(cheques, ids[i], 0) || "",
                'Amount': this.PropertyValue(cheques, ids[i], 1) || "",
                'Date': this.PropertyValue(cheques, ids[i], 2) || "",
                'BankName': this.PropertyValue(cheques, ids[i], 3) || "",
                'DrawnOn': this.PropertyValue(cheques, ids[i], 4) || "",
                'Created': this.CreatedBy
            };
        }
    }

    PropertyValue(items, modelId, pos) {
        return items.filter(m => m.model == modelId)[pos].value;
    }

    ModelBuilder() {

        let d1 = {};
        let d2 = {};

        for (var i = 0; i <= this.ctrl.length - 1; i++) {
            let c = this.ctrl[i];
            let model = c["model"];
            let key = c["id"];
            let val = c["value"];

            switch (model) {
                case 'member':
                    this.member[key] = val;
                    break;
                case 'spouse':
                    this.spouse[key] = val;
                    break;
                case 'dependent_1':
                case 'dependent_2':
                    if (model === "dependent_1") {
                        d1[key.substr(4)] = val;
                    } else {
                        d2[key.substr(4)] = val;
                    }
                    break;
                case 'payment':
                    this.payment[key] = val;
                    break;
                default:
                    break;
            }
        }
        this.dependent["d0"] = d1;
        this.dependent["d1"] = d2;

        if (this.paymentMode === Mode.CHQ || this.paymentMode === Mode.MXM) {
            var cheques = this.ctrl.filter(function (item) {
                return item.isChequeModel === true;
            });
            this.ChequeModelBuilder(cheques);
        }
        
    }

    ValidateForm() {
        var sb_msg = new StringBuilder();
        for (var i = 0; i <= this.ctrl.length - 1; i++) {
            let c = this.ctrl[i];
            let model = c["model"];
            let val = c["value"];
            let required = c["isRequired"];
            let message = c["errorMessage"];
            let tab = c["model"];
            if (required && !val) {
                sb_msg.append("<li> Tab " + tab + " - " + message + "</li>");
                //console.log('Model : ' + model + ', Control: ' + c.id + ', Value : ' + val);
            }
        }

        if (sb_msg.strings.length > 0) {
            $('.modal-title').html("Error List");
            $('.modal-body>ul').html(sb_msg.toString());
            $("#error-model").modal({ show: true });
            return false;
        }
        else {
            return true;
        }
    }

    SubmitForm() {

        this.paymentMode = $("#PaymentMode").val();
        if (!this.paymentMode) {
            toastr.warning("Payment mode must be selected", "Payment");
            return false;
        } else {
            toastr.info("Pleas wait while your data is getting save :)", "Saving");
        }


        //this.isPayByCheque = $("#IsPayByCheque").value;
        this.FormControlExtraction();
        //this.ModelBuilder();
        //return false;
        if (!this.ValidateForm()) {
            return false;
        }
        else {
            this.ModelBuilder();

            var models = {};
            models["o0"] = this.member;
            models["o1"] = this.spouse;
            models["o2"] = this.dependent;
            models["o3"] = this.payment;
            models["o4"] = this.cheque;
            models["o5"] = { IsNew: this.IsNew };
            //console.log(JSON.stringify(models));
            //  return false;
            $.ajax({
                url: "/api/member/post",
                type: "POST",
                contentType: "application/json",
                //dataType: "json",
                data: JSON.stringify(models),
                success: function (result) {
                    toastr.success(result);
                    console.log(result);
                },
                error: function (xhr, resp, text) {
                    toastr.error(xhr.responseText, resp);
                    console.log(xhr, resp, text);
                }
            });
        }
    }
}
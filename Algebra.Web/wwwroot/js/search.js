


class Search {
    constructor(param) {
        this.text = param.text;
        this.ismember = param.ismember;
        this.action = param.searchfor;
        this.controller = "search";
        this.source = param.source;
    }

    validate() {
        if (!this.text) {
            toastr.warning("Search Text is required!", "Search Text?");
            return false;
        }
        if (!this.ismember) {
            toastr.warning("I am not sure, is this a member or what?", "Member/Invitee?");
            return false;
        }

        if (!this.controller) {
            toastr.warning("What you looking for? please be specific!", "Search For?");
            return false;
        }

        return true;
    }

    submit() {
        if (!this.validate()) {
            toastr.error("Validation failed", "Validation error");
            return false;
        }
        //this.url = "api/search/" + this.searchfor;
        // toastr.success(this.url, "ok");
        var param = { text: this.text };
        var jsonData = GetJSON(this.controller, this.action, this.text);
        console.log(jsonData);
    }

}
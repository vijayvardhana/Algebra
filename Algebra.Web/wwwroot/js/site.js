// Write your JavaScript code.

const Tabs = {
    MEM: 'member',
    SPO: 'spouse',
    DEP: 'dependent',
    FEE: 'membership-fee',
    AST: 'assets'
}

const Mode = {
    BTR: '1', //Bank Transfer
    CAS: '2', //Cash
    CHQ: '3', //Cheque
    CCD: '4', //Credit Card
    DCD: '5', //Debit Card
    DFT: '6', //Draft
    NTB: '7', //Net Banking
    MXM: '8' //Mix Mode
}




//String Builder class
function StringBuilder(value) {
    this.strings = new Array();
    this.append(value);
}

StringBuilder.prototype.append = function (value) {
    if (value) {
        this.strings.push(value);
    }
}

StringBuilder.prototype.clear = function () {
    this.strings.length = 1;
}

StringBuilder.prototype.toString = function () {
    return this.strings.join("");
}

String.format = function (format) {
    var args = Array.prototype.slice.call(arguments, 1);
    return format.replace(/{(\d+)}/g, function (match, number) {
        return typeof args[number] != 'undefined'
            ? args[number]
            : match
            ;
    });
};



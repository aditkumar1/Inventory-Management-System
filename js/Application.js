$(document).ready(function () {
    $(".tabs > ul").tabs();
});
function alertError(val) {
    alert(val);
    return false;
}
function alertRequest(val, val1) {
    alert(val);
    window.location.href = val1;
    return false;
}
function RadioCheck(rb, gvName) {
    gvId = $("table[id$=" + gvName + "]").attr('id');
    var gv = document.getElementById(gvId);
    var rbs = gv.getElementsByTagName("input");
    var row = rb.parentNode.parentNode;
    for (var i = 0; i < rbs.length; i++) {
        if (rbs[i].type == "radio") {
            if (rbs[i].checked && rbs[i] != rb) {
                rbs[i].checked = false;
                break;
            }
        }
    }
}
function PrintPanel(pName) {
    var panelId = $("div[id$=" + pName + "]").attr('id');
    var panel = document.getElementById(panelId);
    var printWindow = window.open('', '', 'height=400,width=800');
    printWindow.document.write('<html><head><title>DIV Contents</title>');
    printWindow.document.write('</head><body >');
    printWindow.document.write(panel.innerHTML);
    printWindow.document.write('</body></html>');
    printWindow.document.close();
    setTimeout(function () {
        printWindow.print();
    }, 500);
    return false;
}

function WebForm_OnSubmit() {
    if (typeof (ValidatorOnSubmit) == "function" && ValidatorOnSubmit() == false) {
        for (var i in Page_Validators) {
            try {
                var control = document.getElementById(Page_Validators[i].controltovalidate);
                if (!Page_Validators[i].isvalid) {
                    control.className = "ErrorControl";
                } else {
                    control.className = "";
                }
            } catch (e) { }
        }
        return false;
    }
    return true;
}
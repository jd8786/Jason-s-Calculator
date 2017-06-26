$(document).ready(
    function () {
        //debugger;
        var txt = $("#txt");
        txt.keypress(function (e) {
            if (String.fromCharCode(e.keyCode).match(/[^0-9+-/*]/g)) return false;
        });

        $(".number").click(function () {
            var result = txt.val();
            var number = $(this).attr("value");
            if (result == "0") {
                txt.val(number);
            } else {
                txt.val(result + number);
            }
        });

        $(".operator").click(function () {
            var result = txt.val();
            var operator = $(this).attr("value");
            var lastChar = result.slice(-1);
            var valid_operators = [];
            $(".operator").each(function (index, element) {
                valid_operators.push($(element).attr("value"));
            });
            if (valid_operators.indexOf(lastChar) > -1 || result === "") { } else {
                txt.val(result + operator);
            }
        });


        $("#dot").click(function () {
            var result = txt.val();
            var lastChar = result.slice(-1)
            if (lastChar == ".") { } else {
                txt.val(result + ".")
            }
        });

        $("#ce").click(function () {
            var result = txt.val();
            txt.val(result.substring(0, result.length - 1))
        });

        $("#re").click(function () {
            txt.val("");
        });

        $("#eq").click(function () {
            if (result === "") {
            }
        });
    }
);


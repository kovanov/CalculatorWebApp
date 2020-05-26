const api = {
    host: 'https://localhost:44367',
    controller: 'Math'
}

const methodMap = {
    '1': 'Add',
    '2': 'subtract',
    '3': 'divide',
    '4': 'multiply',
};

$('#sendRequest').on('click', function (e) {
    $('#errorBox').text('');
    let request = {
        operand1: +$('#operand1').val(),
        operand2: +$('#operand2').val(),
        usecolors: true
    };
    var method = methodMap[$('#methodSelector').val()];

    $.ajax({
        type: 'post',
        url: `${api.host}/${api.controller}/${method}`,
        data: JSON.stringify(request),
        dataType: 'json',
        contentType: 'application/json',
        success: function (x) {
            if (x.errorCode)
                $('#errorBox').text(x.error);
            else {
                var resultBox = $('#result');
                resultBox.val(x.data.result);
                var options = x.data.options;
                if (options && options.color) {
                    resultBox.css({ 'color': options.color });
                }
            }
        },
        error: function (error) {
            $('#errorBox').text('Network error');
        }
    });
});
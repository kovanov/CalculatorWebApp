const api = {
    host: 'https://localhost:44367',
    controller: 'Math'
}

$('#sendRequest').on('click', function (e) {
    $('#errorBox').text('');
    let request = {
        operands: [+$('#operand1').val(), +$('#operand2').val()],
        operationId:+$('#methodSelector').val()
    };

    $.ajax({
        type: 'post',
        url: `${api.host}/${api.controller}/Calculate`,
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
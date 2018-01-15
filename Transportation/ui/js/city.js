$(function () {
    var baseUrl = "http://localhost:62962/";
    /*--------------------------------GET ALL CITIES--------------------------------------*/
    GetAll(baseUrl);
    /*-------------------------------------ADD CITY----------------------------------------------*/
    $('#addCity').click(function () {
        var nameCity = $('#cityName').val();
        $.ajax({
            method: 'post',
            url: baseUrl + 'api/cities',
            data: { name: nameCity },
            success: function (data) {
                var row = '<tr data-id="' + data[i].id + '"><th scope="row">#</th><td>' + data.name + '<td><button class="btn btn-secondary" data-toggle="modal" data-target="#editCity">Edit</button></td><td><button class="btn btn-danger">Delete</button></td></tr>';
                $('#cityTable').append(row);
                $('#cityName').val("");
            }
        });
    });
    /*----------------------------DELETE CITY------------------------------*/
    $(document).on("click", '#cityTable .btn-danger', function () {
        var row = $(this).closest('tr');
        var id = row.data('id');
        $.ajax({
            method: 'delete',
            url: baseUrl + 'api/cities/' + id,
            success: function (data) {
                row.remove();
            }
        });
    });

    $(document).on("click", "td .btn-secondary", function () {
        var id = $(this).closest('tr').data('id');
        $.ajax({
            method: 'get',
            url: baseUrl + 'api/cities/' + id,
            success: function (data) {
                $('#newName').val(data.name);
            }
        });
        $('#save').click(function () {
            var name = $('#newName').val();
            $.ajax({
                method: 'put',
                url: baseUrl + 'api/cities/' + id + '/' + name,
                success: function (data) {
                    GetAll(baseUrl);
                    $('.close').click();
                }
            });
        });
    });
});

function GetAll(baseUrl) {
    $.ajax({
        method: 'get',
        url: baseUrl + 'api/cities',
        success: function (data) {
            var rows = "";
            for (var i = 0; i < data.length; i++) {
                rows += '<tr data-id="' + data[i].id + '"><th scope="row">' + (i + 1) + "</th><td>" + data[i].name + '</td><td><button class="btn btn-secondary" data-toggle="modal" data-target="#editCity">Edit</button></td><td><button class="btn btn-danger">Delete</button></td></tr>';
            }
            $('#cityTable').html(rows);
        }
    });
}
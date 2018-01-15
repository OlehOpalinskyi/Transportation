$(function () {
    var baseUrl = "http://localhost:62962/";
    /*--------------------------------GET ALL CITIES--------------------------------------*/
    GetAll(baseUrl);
    /*---------------------LOAD ROUTES TO SELECT-------------------------------*/
    $.ajax({
        method: 'get',
        url: baseUrl + 'api/routes',
        success: function (data) {
            var options = '';
            for (var i = 0; i < data.length; i++) {
                option += '<option value="' + data[i].id + '">' + data[i].pointA + '-' + data[i].pointB + '</option>';
            }
            $('#routeSelect').html(options);
        }
    });
    /*-----------------------ADD BUS---------------------------------------*/
    $('#addBus').click(function () {
        var number = $('#busNumber');
        var count = $('#countPas');
        var obj = {
            numberOfBus: number.val(),
            countOfPassengers: count.val()
        };
        $.ajax({
            method: 'post',
            url: baseUrl + 'api/buses',
            data: obj,
            success: function (data) {
                var row = '<tr data-id="' + data.id + '"><th scope="row">#</th><td>' + data.numberOfBus + '</td><td>' + data.countOfPassengers +
                    '<td><button class="btn btn-success">Show routes</button></td><td><button class="btn btn-primary" data-toggle="modal" data-target="#modalRoute">Add route</button></td><td><button class="btn btn-secondary" data-toggle="modal" data-target="#editBus">Edit</button></td><td><button class="btn btn-danger">Delete</button></td></tr>';
                number.val("");
                count.val("");
                $('#busTable').append(row);
            }
        });
    });
    /*-----------------------EDIT BUS--------------------------------*/
    $(document).on("click", "td .btn-secondary", function () {
        var id = $(this).closest('tr').data('id');
        $.ajax({
            method: 'get',
            url: baseUrl + 'api/buses/' + id,
            success: function (data) {
                $('#number').val(data.numberOfBus);
                $('#count').val(data.countOfPassengers);
            }
        });
        $('#save').click(function () {
            var obj = {
                numberOfBus: $('#number').val(),
                countOfPassengers: $('#count').val()
            };

            var name = $('#number').val();
            $.ajax({
                method: 'put',
                url: baseUrl + 'api/buses/' + id,
                data: obj,
                success: function (data) {
                    GetAll(baseUrl);
                    $('.close').click();
                }
            });
        });
    });
    /*----------------------------DELETE BUS------------------------------*/
    $(document).on("click", '#busTable .btn-danger', function () {
        var row = $(this).closest('tr');
        var id = row.data('id');
        $.ajax({
            method: 'delete',
            url: baseUrl + 'api/buses/' + id,
            success: function (data) {
                row.remove();
            }
        });
    });
    /*-----------------------SHOW ROUTES-----------------------*/
    $(document).on('click', '#busTable .btn-success', function () {
        var id = $(this).closest('tr').data('id');
        $.ajax({
            method: 'get',
            url: baseUrl + 'api/bus/' + id + "/routes",
            success: function (data) {
                var rows = '';
                for (var i = 0; i < data.length; i++) {
                    rows += '<tr data-id="' + data[i].id + '"><th scope="row">' + (i + 1) + "</th><td>" + data[i].pointA + '</td><td>' + data[i].pointB + '</td><td>' + data[i].price +
                    '</td><td><button class="btn btn-danger">Delete</button></td></tr>';
                }
                $('#routeTable').html(rows);
                $('#routes').show();
            }
        });
        /*----------------------------DELETE ROUTE IN BUS------------------------------*/
        $(document).on("click", '#routeTable .btn-danger', function () {
            var row = $(this).closest('tr');
            var idRoute = row.data('id');
            $.ajax({
                method: 'delete',
                url: baseUrl + 'api/bus/' + id + "/routes/remove/" + idRoute,
                success: function (data) {
                    row.remove();
                }
            });
        })
    });
    /*----------------------------------ADD ROUTE TO BUS----------------------*/
    $(document).on("click", '#routeTable .btn-primary', function () {
        var busId = $(this).closest('tr').data('id');
        
    });
});

function GetAll(baseUrl) {
    $.ajax({
        method: 'get',
        url: baseUrl + 'api/buses',
        success: function (data) {
            var rows = "";
            for (var i = 0; i < data.length; i++) {
                rows += '<tr data-id="' + data[i].id + '"><th scope="row">' + (i + 1) + "</th><td>" + data[i].numberOfBus + '</td><td>' + data[i].countOfPassengers +
                    '<td><button class="btn btn-success">Show routes</button></td><td><button class="btn btn-primary" data-toggle="modal" data-target="#modalRoute">Add route</button></td><td><button class="btn btn-secondary" data-toggle="modal" data-target="#editBus">Edit</button></td><td><button class="btn btn-danger">Delete</button></td></tr>';
            }
            $('#busTable').html(rows);
        }
    });
}
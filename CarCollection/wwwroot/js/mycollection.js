var dataTable;

$(document).ready(function () {
    loadList();
});
// MY REVIEW TABLE
function loadList() {
    dataTable = $('#DT_load').DataTable({
        "ajax":
        {
            "url": "/api/myreview",
            "type": "GET",
            "datatype": "json"
        },
        "columns":
            [
                {
                    data: "image", "aTargets": [0], "render": function (data) { return '<img src="' + data + '" class="card-img-top p-2 rounded" id="collectionImg" />'; }
                    , width: "50%"
                },
                {
                    data: "car.carName", width: "15%"
                },
                {
                    data: "rating", width: "5%"
                },
                {
                    data: "id",
                    "render": function (data) {
                        return `
                        <div class="text-center">
                            <a href="/Customer/Review/Details?id=${data}"
                               class="btn btn-info text-white" style="cursor: pointer; width: 100px;">
                                <i class="fas fa-book-open"></i>
                                Read 
                            </a>
                            <br/>
                            <a href="/Customer/Review/Upsert?id=${data}"
                               class="btn btn-success text-white" style="cursor: pointer; width: 100px;">
                                <i class="far fa-edit"></i>
                                Edit 
                            </a>
                            <br/>
                            <a onClick=Delete('/api/review/'+${data})
                               class="btn btn-danger text-white" style="cursor: pointer"; width: 100px;">
                                <i class="far fa-trash-alt"></i>
                                Delete
                            </a>
                        </div>
                        `}, width: "20%"

                }
            ],
        "sDom": 'lrtip',
        "fnInitComplete": function (oSettings, json) {
            addSearchControl(json);
        },
        "lengthMenu": [[5, 10, 25, -1], [5, 10, 25, "All"]],
        "language": {
            "emptyTable": "no data found."
        },
        "width": "100%"
    });
}
// FILTERING MY REVIEWS FUNCTION
function addSearchControl(json) {
    $("#DT_load thead").append($("#DT_load thead tr:first").clone());                           // Clone the First row
    $("#DT_load thead tr:eq(1) th").each(function (index) {                                     // Look at the header of each column for the cloned row
        if (index == 0) { $(this).replaceWith('<th></th >'); }                                              // Replace button column header with an empty header (no search bar)
        if (index == 1) {
            var carDropDown = $('<select/>');
            carDropDown.append($('<option/>').attr('value', '').text('Select Car'));
            var car = [];
            $(json.data).each(function (index, element) {
                if ($.inArray(element.car.carName, car) == -1) {
                    car.push(element.car);
                    carDropDown.append($('<option/>').attr('value', element.car.carName).text(element.car.carName));
                }
            });
            $(this).replaceWith('<th>' + $(carDropDown).prop('outerHTML') + '</th>');
            var searchControl = $("#DT_load thead tr:eq(1) th:eq(" + index + ") select");
            searchControl.on('change', function () {
                dataTable.column(index).search(searchControl.val() == "" ? "" : '^' + searchControl.val() + '$', true, false).draw();
            });
        }
        if (index == 2) {
            var ratingDropDown = $('<select/>');
            ratingDropDown.append($('<option/>').attr('value', '').text('Select Rating'));
            var rating = [];
            $(json.data).each(function (index, element) {
                if ($.inArray(element.rating, rating) == -1) {
                    rating.push(element.rating);
                    ratingDropDown.append($('<option/>').attr('value', element.rating).text(element.rating));
                }
            });
            $(this).replaceWith('<th>' + $(ratingDropDown).prop('outerHTML') + '</th>');
            var searchControl = $("#DT_load thead tr:eq(1) th:eq(" + index + ") select");
            searchControl.on('change', function () {
                dataTable.column(index).search(searchControl.val() == "" ? "" : '^' + searchControl.val() + '$', true, false).draw();
            });
        }
    });
}
//DELETE FUNCTION
function Delete(url) {
    swal({
        title: "Are you sure you want to delete?",
        text: "You will not be able to restore the date!",
        icon: "warning",
        buttons: true,
        dangerMode: true
    }).then((willDelete) => {
        if (willDelete) {
            $.ajax({
                type: 'DELETE',
                url: url,
                success: function (data) {
                    if (data.success) {
                        toastr.success(data.message);
                        dataTable.ajax.reload();
                    }
                    else {
                        toastr.error(data.message);
                    }
                }
            });
        }
    });
}
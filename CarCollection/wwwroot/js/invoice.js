var dataTable;

$(document).ready(function () {
    loadList();
});

function loadList() {
    dataTable = $('#DT_load').DataTable({
        "ajax":
        {
            "url": "/api/invoice",
            "type": "GET",
            "datatype": "json"
        },
        "columns":
            [
                {
                    data: "id", width: "11%"
                },
                {
                    data: "quantity", width: "11%"
                },
                {
                    data: "value", width: "11%"
                },
                {
                    data: "date", width: "11%"
                },
                {
                    data: "carId", width: "11%"
                },
                {
                    data: "car.carName", width: "11%"
                },
                {
                    data: "applicationUserId", width: "11%"
                },
                {
                    data: "applicationUser.fullName", width: "11%"
                },
                {
                    data: "id",
                    "render": function (data) {
                        return `
                        <div class="text-center">
                            <a href="/Admin/Invoice/Upsert?id=${data}"
                               class="btn btn-success text-white" style="cursor: pointer; width: 100px;">
                                <i class="far fa-edit"></i>
                                Edit 
                            </a>
                            <a onClick=Delete('/api/invoice/'+${data})
                               class="btn btn-danger text-white" style="cursor: pointer"; width: 100px;">
                                <i class="far fa-trash-alt"></i>
                                Delete
                            </a>
                        </div>
`}, width: "11%"

                }

            ],
        "language": {
            "emptyTable": "no data found."
        },
        "width": "100%"
    });
}
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
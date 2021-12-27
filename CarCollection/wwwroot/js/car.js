var dataTable;

$(document).ready(function () {
    loadList();
});

function loadList() {
    dataTable = $('#DT_load').DataTable({
        "ajax":
        {
            "url": "/api/car",
            "type": "GET",
            "datatype": "json"
        },
        "columns":
            [
                {
                    data: "id", width: "14%"
                },
                {
                    data: "make", width: "14%"
                },
                {
                    data: "model", width: "14%"
                },
                {
                    data: "year", width: "14%"
                },
                {
                    data: "condition", width: "14%"
                },
                {
                    data: "price", width: "14%"
                },
                {
                    data: "id",
                    "render": function (data) {
                        return `
                        <div class="text-center">
                            <a href="/Admin/car/Upsert?id=${data}"
                               class="btn btn-success text-white" style="cursor: pointer; width: 100px;">
                                <i class="far fa-edit"></i>
                                Edit 
                            </a>
                            <a onClick=Delete('/api/car/'+${data})
                               class="btn btn-danger text-white" style="cursor: pointer"; width: 100px;">
                                <i class="far fa-trash-alt"></i>
                                Delete
                            </a>
                        </div>
`}, width: "14%"

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
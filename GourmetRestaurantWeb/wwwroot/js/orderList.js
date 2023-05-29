var dataTable;
dataTable = new DataTable('#DT_Load', {
    "ajax": {
        "url": "/api/Order",
        "type": "GET",
        "datatype": "json"
    },
    "columns": [
        { "data": "id", "width": "15%" },
        { "data": "pickupName", "width": "15%" },
        { "data": "applicationUser.email", "width": "15%" },
        { "data": "orderTotal", "width": "15%" },
        { "data": "pickUpTime", "width": "25%" },
        {
            "data": "id",
            "render": function (data) {
                return `<div class="w-100 btn-group">
                        <a href="/Admin/Order/OrderDetails?id=${data}" class="btn btn-success text-white mx-2 py-2">
                        <i class="bi bi-pencil-square"></i> </a>
                        </div>`
            },

            "width": "15%"
        }
    ],
    columnDefs: [{
        targets: 4, // Date column index
        render: function (data) {
            return moment(data).format('YYYY-MM-DD HH:mm:ss');
        }
    }],
    
    "width": "100%"
});




function Delete(url) {
    Swal.fire({
        title: 'Are you sure?',
        text: "You won't be able to revert this!",
        icon: 'warning',
        showCancelButton: true,
        confirmButtonColor: '#3085d6',
        cancelButtonColor: '#d33',
        confirmButtonText: 'Yes, delete it!'
    }).then((result) => {
        if (result.isConfirmed) {
            $.ajax({
                url: url,
                type: 'DELETE',
                success: function (data) {
                    if (data.success) {
                        dataTable.ajax.reload();
                        //success notification
                        toastr.success(data.message);
                    }
                    else {
                        //failure notification
                        toastr.error(data.message);
                    }
                }
            })
        }
    })
}
var dataAll = [];
var columnMain = [
    { "title": "ID" },
    { "title": "Code" },
    { "title": "Name" },
    { "title": "Remark" },
    { "title": "Create Date" },
    { "title": "Modify Date" },
    {
        data: null,
        className: 'dt-center editor-edit',
        defaultContent: '<i class="fas fa-pen"/>',
        orderable: false
    },
    {
        data: null,
        className: 'dt-center editor-delete',
        defaultContent: '<i class="fas fa-trash"/>',
        orderable: false
    }
];

//============================== Event =============================================================
$(document).ready(function () {
    //Load datatable
    BindData_Table(dataAll);
    GetAll();
});

$('#createModal').on('show.bs.modal', function (event) {
    var button = $(event.relatedTarget) // Button that triggered the modal
    var recipient = button.data('whatever') // Extract info from data-* attributes
    // If necessary, you could initiate an AJAX request here (and then do the updating in a callback).
    // Update the modal's content. We'll use jQuery here, but you could use a data binding library or other methods instead.
    var modal = $(this)
    // modal.find('.modal-title').text('New message to ' + recipient)
    // modal.find('.modal-body input').val(recipient)
});

//============================== Function =============================================================
async function GetAll(){
    let url = $('#GetMatTypeAll').data('request-url');
    console.log(url);
    $.ajax({
        type: 'GET',
        url: url,
        // data: { yearmon: yearMon, method: sqlType },
        success: async function (res) {
            if (res.IsError) {
                console.log("Error!!!!!");
            } else {
                console.log(res);
                //Reset dataAll = [];
                dataAll = [];
                for (var i = 0; i < res.length; i++) {
                    dataAll.push([
                        res[i]["type_Id"],
                        res[i]["type_Code"],
                        res[i]["type_Name"],
                        res[i]["type_Remark"],
                        formatDate(res[i]["create_Date"]),
                        res[i]["modify_Date"]=="0001-01-01T00:00:00"?"":res[i]["modify_Date"]
                    ]);
                }
                //Bind data to datatable
                await BindData_Table(dataAll);
            }
        }
    });
}

//Format date
function formatDate(date) {
    var d = new Date(date),
        month = '' + (d.getMonth() + 1),
        day = '' + d.getDate(),
        year = d.getFullYear();

    if (month.length < 2) 
        month = '0' + month;
    if (day.length < 2) 
        day = '0' + day;

    return [year, month, day].join('-');
}


//Function Bind data to datatable
async function BindData_Table(data) {
    $("#dataTables").DataTable({
        "lengthMenu": [
            [15, 20, 50, 100, -1],
            [15, 20, 50, 100],
        ],
        columns: columnMain,
        columnDefs: [
            {
                targets: [0,1,2,3,4,5],
                className: 'dt-body-center'
            }
        ],
        destroy: true,
        data: data,
        "scrollX": true,
    });
}



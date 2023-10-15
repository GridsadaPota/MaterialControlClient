// //============================== Set variable =============================================================
// var dataAll = [];
// var table = $('#dataTables').dataTable();

// //============================== Event =============================================================
// $(document).ready(function () {
//     //Load datatable
//     GetAll();
// });

// table.on('click', 'tbody span.edit', function (e) {
//     e.preventDefault();
//     console.log("Edit");
//     //Assign table again.
//     var table = $( "#dataTables" ).DataTable();
//     let data = table.row(e.target.closest('tr')).data();
//     console.log(data);
//     // window.location.href = '@Url.Action("Edit", "Material", new{ model="'+ data +'"})'

// });

// // Delete row
// table.on('click', 'tbody span.remove', function (e) {
//     e.preventDefault();
//     console.log("Delete");
// });

// //============================== Function =============================================================
// //Function Bind data to datatable
// async function Load_DataTable() {
//     table.DataTable({
//         "lengthMenu": [
//             [15, 20, 50, 100, -1],
//             [15, 20, 50, 100],
//         ],
//         columns: [
//             { "title": "ID" },
//             { "title": "Code" },
//             { "title": "Name" },
//             { "title": "Remark" },
//             { "title": "Create Date" },
//             { "title": "Modify Date" },
//             {
//                 data: 'type_Id',
//                 defaultContent:
//                     '<div class="action-buttons">' +
//                     '<span class="edit"><i class="fas fa-pen"></i></span> ' +
//                     '<span class="remove"><i class="fa fa-trash"></i></span> ' +
//                     '</div>',
//                 className: 'row-edit dt-center',
//                 orderable: false
//             }
//         ],
//         columnDefs: [
//             {
//                 targets: [0,1,2,3,4,5],
//                 className: 'dt-body-center'
//             }
//         ],
//         destroy: true,
//         data: dataAll,
//         "scrollX": true
//     });
// }

// //Get All Material type
// async function GetAll(){
//     let url = $('#GetMatTypeAll').data('request-url');
//     $.ajax({
//         type: 'GET',
//         url: url,
//         // data: { yearmon: yearMon, method: sqlType },
//         success: async function (res) {
//             if (res.IsError) {
//                 console.log("Error!!!!!");
//             } else {
//                 // console.log(res);
//                 //Reset dataAll = [];
//                 dataAll = [];
//                 for (var i = 0; i < res.length; i++) {
//                     dataAll.push([
//                         res[i]["type_Id"],
//                         res[i]["type_Code"],
//                         res[i]["type_Name"],
//                         res[i]["type_Remark"],
//                         formatDate(res[i]["create_Date"]),
//                         res[i]["modify_Date"]=="0001-01-01T00:00:00"?"":res[i]["modify_Date"],
//                         null
//                     ]);
//                 }
//                 //Bind data to datatable
//                 await Load_DataTable();
//             }
//         }
//     });
// }

// //Format date
// function formatDate(date) {
//     var d = new Date(date),
//         month = '' + (d.getMonth() + 1),
//         day = '' + d.getDate(),
//         year = d.getFullYear();

//     if (month.length < 2) 
//         month = '0' + month;
//     if (day.length < 2) 
//         day = '0' + day;

//     return [year, month, day].join('-');
// }
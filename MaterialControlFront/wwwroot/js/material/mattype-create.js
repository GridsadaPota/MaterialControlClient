// $(function () {
//   $('#createForm').validate({
//     rules: {
//       type_code: {
//         required: true,
//         minlength: 3
//       },
//       type_name: {
//         required: true,
//         minlength: 3
//       }
//     },
//     messages: {
//       type_code: {
//         required: "กรุณาระบุ material type code",
//         minlength: "รหัส Material Type ต้องมีความยาวอย่างน้อย 3 อักขระ"
//       },
//       type_name: {
//         required: "กรุณาระบุ material type name",
//         minlength: "ชื่่อ Material Type ต้องมีความยาวอย่างน้อย 3 อักขระ"
//       },
//     },
//     errorElement: 'span',
//     errorPlacement: function (error, element) {
//       error.addClass('invalid-feedback');
//       element.closest('.form-group').append(error);
//     },
//     highlight: function (element, errorClass, validClass) {
//       $(element).addClass('is-invalid');
//     },
//     unhighlight: function (element, errorClass, validClass) {
//       $(element).removeClass('is-invalid');
//     },
//     // Make sure the form is submitted to the destination defined
//     // in the "action" attribute of the form when valid
//     submitHandler: function(form) {
//       //assign data
//       var data = {
//         type_code: $(form).find('input[name="type_code"]').val(),
//         type_name: $(form).find('input[name="type_name"]').val(),
//         type_remark: $(form).find('textarea[name="type_remark"]').val()
//       };

//       // Add data
//       Add_MatterialType(data);
//     }
//   });
  
// });

// function Add_MatterialType(data){
// let url = $('#GetMatTypeByCode').data('request-url');
// let url2 = $('#AddMatType').data('request-url');
// /*============ Check code duplicate before add =============*/
// //declare parameter by json
// var findData = { "code": data.type_code };
// var res = getData(url, findData);
// var result = res.responseJSON;
// console.log(res.responseJSON);


// if (result.type_Code !== null){
//   // console.log("Duplicated!");
//   var msg = "รหัสซ้ำ ("+ result.type_Code +"), กรุณาตรวจสอบรหัส Material Type อีกครั้ง!"
//   $('#createForm').append("<div class='span text-red'>"+ msg +"</div>");

// }else{
//   //assign value
//   var model = {
//     type_id: 0,
//     type_code: data.type_code,
//     type_name: data.type_name,
//     type_remark: data.type_remark
//   }
//   //convert model to json
//   var modelJson = JSON.stringify(model);
//   var res2 = addData(url2, modelJson); 

//   // console.log(res2.responseJSON);
//   var currentUrl = window.location.href;
//   msgsuccess_redirect("บันทึกข้อมูลเรียบร้อย!",2000, currentUrl);
// }
// }

// $("#btnBack").click(function(e){
// // let previousUrl  = document.referrer;
// // console.log(previousUrl );
// history.back();
// });

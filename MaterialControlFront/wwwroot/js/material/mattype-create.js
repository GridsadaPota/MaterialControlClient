$(function () {
    $('#createForm').validate({
      rules: {
        type_code: {
          required: true,
          minlength: 5
        },
        type_name: {
          required: true,
          minlength: 5
        }
      },
      messages: {
        type_code: {
          required: "Please enter a material type code",
          minlength: "Your material type code must be at least 5 characters long"
        },
        type_name: {
          required: "Please enter a material type name",
          minlength: "Your material type name must be at least 5 characters long"
        },
      },
      errorElement: 'span',
      errorPlacement: function (error, element) {
        error.addClass('invalid-feedback');
        element.closest('.form-group').append(error);
      },
      highlight: function (element, errorClass, validClass) {
        $(element).addClass('is-invalid');
      },
      unhighlight: function (element, errorClass, validClass) {
        $(element).removeClass('is-invalid');
      },
      // Make sure the form is submitted to the destination defined
      // in the "action" attribute of the form when valid
      submitHandler:  function(form) {
        //assign data
        var data = {
          type_code: $(form).find('input[name="type_code"]').val(),
          type_name: $(form).find('input[name="type_name"]').val(),
          type_remark: $(form).find('textarea[name="type_remark"]').val()
        };
        // console.log(data);

        //chekc duplicate code
        // var chk = Check_MatTypeCode_duplicate(data.type_code);
        // console.log(chk);
        // if(chk){
        //   console.log("Duplicated!!!");
        // }else{
        //   console.log("Complted");
        //   // form.submit();
        // }

        Check_MatTypeCode_duplicate(data.type_code);
      }
    });
    
});


async function Check_MatTypeCode_duplicate(type_code){
  var chk_dup = false;
  let url = $('#GetMatTypeByCode').data('request-url');
  //declare parameter by json
  var findData = { "code": type_code };
  const res = await getData(url, findData);
  console.log(res);
  console.log(res.type_Code);
  // console.log(res.status);
  if (res.type_Code !== null){
    msgerror("รหัสซ้ำ ("+ res.type_Code +"), กรุณาตรวจสอบรหัส Material Type อีกครั้ง!", 3000);
  }else{
    // msgsuccess("บันทึกข้อมูลเรียบร้อย!",3000);
    msgsuccess_redirect("บันทึกข้อมูลเรียบร้อย!",3000, "https://localhost:7245/Material/Index");
  }
}

// // async function Create(data){
// //   let url = $('#AddMatType').data('request-url');
// //   console.log(data.type_code);

// //   var dup = await Check_MatTypeCode_duplicate(data.type_code);
// //   if (dup){
// //     alert("It is already!");
// //   }else{
// //     alert( "Form successful submitted!" );
// //   }
// // }

// // $("#createForm").submit(function(e){
// //   e.preventDefault();

// //   console.log("5555555555555555");
// // });

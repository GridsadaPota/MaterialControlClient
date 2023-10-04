//Function Getdata and return by json
function getData(Url, findData) {
    return $.ajax({
        async: false,
        type: "GET",
        url: Url,
        data: findData,
        contentType: "application/json; charset=utf-8",
        dataType: "json"
    });
}

//Function Getdata and return by json
function addData(Url, addData) {
    return $.ajax({
        async: false,
        type: "POST",
        url: Url,
        data: addData,
        contentType: "application/json; charset=utf-8",
        dataType: "json"
    });
}

//Function Wait
async function WaitSecond(num) {
    await new Promise(resolve => setTimeout(resolve, num));
}

function msgsuccess(meg, times) {
    Swal.fire({
        icon: 'success',
        title: 'Success',
        text: meg,
        timer: times,
        backdrop: `rgba(0,255,0,0.3)`,
        showCancelButton: false,
        timerProgressBar: true,
        showConfirmButton: false,
        allowOutsideClick: false,
        allowEscapeKey: false,
        allowEnterKey: false,
    });
}

function msgsuccess_redirect(meg, times, url) {
    Swal.fire({
        icon: 'success',
        title: 'Success',
        text: meg,
        timer: times, //4000,
        backdrop: `rgba(0,255,0,0.3)`,
        showCancelButton: false,
        timerProgressBar: true,
        showConfirmButton: false,
        allowOutsideClick: false,
        allowEscapeKey: false,
        allowEnterKey: false,
    }).then(function(){
        window.location.href = url;
    });
}

function msgerror(meg, times) {
    
    Swal.fire({
        icon: 'error',
        title: 'ผิดพลาด',
        timer: times,
        text: meg,
        backdrop: `rgba(249,186,186,0.4)`,
        showCancelButton: false,
        timerProgressBar: true,
        showConfirmButton: false,
        allowOutsideClick: false,
        allowEscapeKey: false,
        allowEnterKey: false,
    });
}
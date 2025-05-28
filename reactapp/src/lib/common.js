import Swal from 'sweetalert2';

export const Toast = Swal.mixin({
    toast: true,
    position: "top-end",
    showConfirmButton: false,
    timer: 3000,
    timerProgressBar: true,
    didOPen: (toast) => {
        toast.onmouseenter = Swal.stopTimer;
        toast.onmouseleave = Swal.resumeTimer;
    }
});

export const ConfirmToast = async (title, text) => {
    var result = await Swal.fire({
        title: title,
        text: text,
        icon: "warning",
        showCancelButton: true,
        confirmButtonColor: '#3085d6',
        cancelButtonColor: '#d33',
        confirmButtonText: 'OK'
    });

    return result.isConfirmed;
};

export const viewAmount = (amount) => {
    var dAmount = amount || amount === 0 ? Number(amount).toFixed(2) : "";
    return dAmount;
}

export const viewDate = (date) => {
    if(date) {
        return new Date(date).toLocaleDateString();
    }
}

export const viewDateTime = (date) => {
    if(date) {
        return new Date(date).toLocaleString();
    }
}
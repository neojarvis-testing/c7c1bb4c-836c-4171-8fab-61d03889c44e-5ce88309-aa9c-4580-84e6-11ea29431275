import Swal from 'sweetalert2';
import { Badge } from 'react-bootstrap';
import { formatDistanceStrict } from 'date-fns'

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
    var dAmount = amount || amount === 0 ? 
        //Number(amount).toFixed(2) : 
        Intl.NumberFormat(undefined, {
            minimumFractionDigits: 2,
            maximumFractionDigits: 2
        }).format(amount) :
        "";
    return dAmount;
}

export const viewDate = (date) => {
    if(date) {
        return new Date(date + "Z").toLocaleDateString();
    }
}

export const viewDateTime = (date) => {
    if(date) {
        return new Date(date + "Z").toLocaleString();
    }
}

export const viewRelatedDateTime = (date) => {
    if(date) {
        var d = new Date(date + "Z");
        return formatDistanceStrict(d, new Date(), { addSuffix: true });
    }
}

export const getBadgeBgForStatus = (status) => {
    switch (status){
        case "Active":
            return "primary";
        case "Pending":
            return "info";
        case "Deactvated":
            return "secondary";
        default:
            return "secondary";
    }
}

export const getBadgeForAccountStatus = (status) => {
    var bg = "warning";
    switch (status){
        case "Active":
            bg = "primary";
            break;
        case "Pending":
            bg = "info";
            break;
        default:
            bg = "warning";
    }

    return (<Badge bg={bg} className='badge-rounded'>{status}</Badge>);
}

export const getBadgeForDepositStatus = (depositStatus) => {
    var bg = "warning";
    switch (depositStatus){
        case "Active":
            bg = "primary";
            break;
        case "Closed":
            bg = "info";
            break;
        default:
            bg = "warning";
    }

    return (<Badge bg={bg} className='badge-rounded'>{depositStatus}</Badge>);
}
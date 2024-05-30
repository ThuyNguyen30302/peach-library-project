// Alert.js
import Swal from 'sweetalert2';
import withReactContent from 'sweetalert2-react-content';

const MySwal = withReactContent(Swal);

class Alert {
    static TYPE_SUCCESS = 'success';
    static TYPE_ERROR = 'error';
    static TYPE_WARNING = 'warning';
    static TYPE_INFO = 'info';
    static TYPE_QUESTION = 'question';

    // static Toast_info(title, message, type = Alert.TYPE_INFO, options = {}) {
    //     MySwal.fire({
    //         title: ` <strong>${title}</strong>`,
    //         html: `
    //     <div style="display: flex; flex-direction: column; align-items: center;">
    //       <div><i class="swal2-icon swal2-${type}"></i></div>
    //       <div>${message}</div>
    //     </div>
    //   `,
    //         toast: true,
    //         text: message,
    //         icon: type,
    //         position: options.position || 'top-end',
    //         showConfirmButton: false,
    //         // timer: options.timer || 1500,
    //         timerProgressBar: false, ...options,
    //     });
    // }

    static Toast_info(title, message, type = Alert.TYPE_INFO, options = {}) {
        MySwal.fire({
            title,
            text: message,
            icon: type,
            position: options.position || 'top-end',
            showConfirmButton: false,
            timer: options.timer || 1500,
            timerProgressBar: false,
            ...options,
        });
    }

    static async Swal_confirm(title, message, confirmButtonColor = '#2f7e17') {
        const result = await MySwal.fire({
            title,
            text: message,
            icon: Alert.TYPE_WARNING,
            showCancelButton: true,
            confirmButtonColor: confirmButtonColor,
            cancelButtonColor: '#d33',
            confirmButtonText: 'Có',
            cancelButtonText: 'Không',
        });

        return result.isConfirmed;
    }
}

export default Alert;

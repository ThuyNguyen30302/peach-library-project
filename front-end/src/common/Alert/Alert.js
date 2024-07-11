import Swal from 'sweetalert2';
import withReactContent from 'sweetalert2-react-content';

const MySwal = withReactContent(Swal);

class Alert {
    static TYPE_SUCCESS = 'success';
    static TYPE_ERROR = 'error';
    static TYPE_WARNING = 'warning';
    static TYPE_INFO = 'info';
    static TYPE_QUESTION = 'question';

    static Toast_info(title, message, type = Alert.TYPE_INFO, options = {}) {
        MySwal.fire({
            title,
            text: message,
            icon: type,
            position: options.position || 'top-end',
            showConfirmButton: false,
            timer: options.timer || 1500,
            timerProgressBar: options.timerProgressBar || false,
            ...options,
        });
    }

    static async Swal_confirm(title, message, confirmButtonColor = '#3eae1c') {
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

    static async Swal_info(title, message, icon = Alert.TYPE_INFO, options = {}) {
        await MySwal.fire({
            title,
            text: message,
            icon: icon,
            confirmButtonColor: '#3085d6',
            confirmButtonText: 'OK',
            ...options,
        });
    }
}

export default Alert;

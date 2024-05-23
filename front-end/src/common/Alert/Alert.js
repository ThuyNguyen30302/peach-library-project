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

  static Toast_info(title, message, type = Alert.TYPE_INFO, options = {}) {
    MySwal.fire({
      toast: true,
      title,
      text: message,
      icon: type,
      position: options.position || 'top-end',
      showConfirmButton: false,
      timer: options.timer || 3000,
      timerProgressBar: true,
      ...options,
    });
  }

  static async Swal_confirm(title, message, confirmButtonColor = '#3085d6') {
    const result = await MySwal.fire({
      title,
      text: message,
      icon: Alert.TYPE_WARNING,
      showCancelButton: true,
      confirmButtonColor: confirmButtonColor,
      cancelButtonColor: '#d33',
      confirmButtonText: 'Yes',
      cancelButtonText: 'No',
    });

    return result.isConfirmed;
  }
}

export default Alert;

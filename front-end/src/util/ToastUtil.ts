import Alert from '../common/Alert/Alert';

export default class ToastUtil {
    static LogErrors(message = 'Log 123') {
        console.log(message);
    }

    static ToastMessage(message = 'Message', type = Alert.TYPE_INFO) {
        Alert.Toast_info('Thông báo', message, type);
    }

    static ToastSuccess(message = 'Success!') {
        this.ToastMessage(message, Alert.TYPE_SUCCESS);
    }

    static ToastUpdateSuccess(message = 'Update success!') {
        this.ToastSuccess(message);
    }

    static ToastSaveSuccess(message = 'Save success!') {
        this.ToastSuccess(message);
    }

    static ToastCreateSuccess(message = 'Create success!') {
        this.ToastSuccess(message);
    }

    static ToastServerError(message = 'Server error, please try again!') {
        this.ToastMessage(message, Alert.TYPE_ERROR);
    }

    static ToastHostError(message = 'Server error, please try again!') {
        this.ToastServerError(message);
    }

    static ToastApiError(message = 'Server error, please try again!') {
        this.ToastServerError(message);
    }

    static ToastDeleteSuccess(message = 'Delete success!') {
        this.ToastSuccess(message);
    }

    static ToastDeleteError(message = 'Data error, please try again!') {
        this.ToastMessage(message, Alert.TYPE_ERROR);
    }

    static ToastError(message = 'Đã có lỗi xảy ra') {
        this.ToastMessage(message, Alert.TYPE_ERROR);
    }

    static ToastWarning(message = 'Xin chú ý') {
        this.ToastMessage(message, Alert.TYPE_WARNING);
    }

    static async DeleteConfirm(message, confirmHandler) {
        const isConfirmed = await Alert.Swal_confirm('Xác nhận', message);
        if (isConfirmed) {
            confirmHandler && confirmHandler();
        }
    }

    static async ConfirmDialog(message, confirmHandler, icon = Alert.TYPE_WARNING) {
        const isConfirmed = await Alert.Swal_confirm('Xác nhận', message, icon);
        if (isConfirmed) {
            confirmHandler && confirmHandler();
        }
    }

    static async NotifyDialog(message, icon = Alert.TYPE_INFO) {
        await Alert.Swal_info('Thông báo', message, icon);
    }
}

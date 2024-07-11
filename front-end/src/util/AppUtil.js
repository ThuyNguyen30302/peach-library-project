export default class AppUtil {
  static formatNumber = (value) => {
    return value.replace(/\B(?=(\d{3})+(?!\d))/g, '.');
  }
}
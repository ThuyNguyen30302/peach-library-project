import axios from "axios";
import _ from "lodash";
import {useRef} from "react";
import {UAParser} from "ua-parser-js";
import {loginSuccessFull, setMenus, setRights, setRoutes} from "../action/action";
import {CHECK_LOGIN, LAYOUT, LOGIN, LOGOUT} from "../constant/ApiConstant";
import {LOG_OUT_SUCCESSFUL} from "../constant/constant";
import {AppStore} from "../store";
import Alert from "../common/Alert/Alert";

axios.defaults.baseURL = process.env.REACT_APP_BASE_URL

export const useRequest = () => {
    const uaParser = new UAParser()
    const userAgentOS = uaParser?.getOS()
    const userAgentBrowser = uaParser?.getBrowser()
    let customUserAgent = ""
    if (!_.isEmpty(userAgentOS) && !_.isEmpty(userAgentBrowser)) {
        customUserAgent = `${userAgentOS.name} - ${userAgentBrowser.name} (${userAgentBrowser.version})`
    }

    const requestConfig = useRef({
        headers: {
            Accept:
                "text/html,application/xhtml+xml,application/xml,application/json;q=0.9,image/webp,*/*;q=0.8",
            "Content-Type": "application/json",
            "custom-user-agent": customUserAgent
        }
    })

    const get = async (url, config) => {
        return await axios
          .get(url, {...requestConfig?.current, ...config})
          .then(res => {
              return {
                  ...res.data
              }
          })
          .catch(e => {
              return {
                  ...e.response?.data
              }
          })
    }

    const post = async (url, data, config) => {
        return await axios
          .post(url, data, {...requestConfig?.current, ...config})
          .then(res => {
              return {
                  ...res.data
              }
          })
          .catch(e => {
              return {
                  ...e.response?.data
              }
          })
    }

    const deleteApi = async (url, config) => {
        return await axios
          .delete(url, {...requestConfig?.current, ...config})
          .then(res => {
              return {
                  ...res.data
              }
          })
          .catch(e => {
              return {
                  ...e.response?.data
              }
          })
    }

    const checkLogin = async () => {
        return await get(CHECK_LOGIN, requestConfig?.current).then(response => {
            if (response?.success) {
                AppStore.dispatch(setRights(response?.result?.rights || []))
                AppStore.dispatch(loginSuccessFull(response?.result?.user))
            }
            return response?.result
        })
    }

    const fetchLayout = async () => {
        return await get(LAYOUT, requestConfig?.current).then(response => {
            if (response?.success) {
                AppStore.dispatch(setMenus(response?.result?.menus))
                AppStore.dispatch(setRoutes(response?.result?.routes))
            }
            return response?.result
        })
    }

    const login = (form, values, callback) => {
        post(LOGIN, values, requestConfig?.current)
            .then(response => {
                if (response.success) {
                    Promise.all([checkLogin(), fetchLayout()]).then(() => {
                        form && form?.unmask()
                        callback && callback()
                    })
                } else {
                    form && form?.unmask()
                    Alert.Toast_info(
                        "Thông báo",
                        "Đăng nhập không thành công!",
                        Alert.TYPE_ERROR,
                        {
                            position: "topRight"
                        }
                    )
                }
            })
            .catch(() => {
                form && form?.unmask()
                Alert.Toast_info(
                    "Thông báo",
                    "Đăng nhập không thành công!",
                    Alert.TYPE_ERROR,
                    {
                        position: "topRight"
                    }
                )
            })
    }

    const logout = async callback => {
        const confirm = await Alert.Swal_confirm(
            "Thông báo",
            "Bạn có chắc muốn đăng xuất không?",
            3
        )
        if (confirm.value === true) {
            get(LOGOUT, requestConfig?.current).then(response => {
                if (response?.success) {
                    AppStore.dispatch({ type: LOG_OUT_SUCCESSFUL })
                    callback && callback()
                }
            })
        }
    }

    return {
        get,
        post,
        deleteApi,
        checkLogin,
        login,
        logout,
        fetchLayout
    }
}

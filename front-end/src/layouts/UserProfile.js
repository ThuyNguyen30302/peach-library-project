import React from 'react';
import {Avatar, List, Popover} from "antd";
import {Link} from "react-router-dom";
import {useRequest} from "../custom-hook/useRequest";
import {UserOutlined} from "@ant-design/icons";
import {useSelector} from "react-redux";

const UserProfile = () => {
  const {logout} = useRequest();
  const {authData} = useSelector((stateRedux) => ({
    authData: stateRedux?.root?.get('authData'),
  }));
  const content = () => {
    return <List>
      <List.Item>
        <div onClick={() => {logout()}}>Đăng xuất</div>
      </List.Item>
    </List>
  }
  
  return (
    <div style={{ display: 'flex'}}>
      <Popover placement={'bottomRight'} title={authData.fullName??'Profile'} content={content}>
        <Avatar size={38} icon={<UserOutlined />} alt="avatar" />
      </Popover>
    </div>
  );
};

export default UserProfile;
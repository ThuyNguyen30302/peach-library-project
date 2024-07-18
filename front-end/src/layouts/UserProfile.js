import React from "react";
import { Avatar, Button, List, Popover } from "antd";
import {Link, useNavigate} from "react-router-dom";
import { useRequest } from "../custom-hook/useRequest";
import { LockOutlined, LogoutOutlined } from "@ant-design/icons";
import { useSelector } from "react-redux";

const UserProfile = () => {
  const { logout } = useRequest();
  const navigate = useNavigate();

  const { authData } = useSelector((stateRedux) => ({
    authData: stateRedux?.root?.get("authData"),
  }));

  const buttonStyle = {
    width: '100%',
    textAlign: 'left',
    padding: '10px',
    height: 'auto',
    display: 'flex',
    alignItems: 'center',
    border: 'none',
    backgroundColor: 'transparent',
    transition: 'background-color 0.3s',
    borderRadius: '4px',
  };


  const content = () => {
    return (
      <List
        split={false}
        style={{
          width: '200px',
          padding: '10px'
        }}
      >
        <List.Item style={{ padding: 0 }}>
          <Button
            type="text"
            icon={<LockOutlined />}
            style={{
              ...buttonStyle,
              color: '#1890ff',
            }}
            onMouseEnter={(e) => e.currentTarget.style.backgroundColor = '#e6f7ff'}
            onMouseLeave={(e) => e.currentTarget.style.backgroundColor = 'transparent'}
            onClick={() => {
              navigate('/change-password');
            }}
          >
            Đổi mật khẩu
          </Button>
        </List.Item>
        <List.Item style={{ padding: 0 }}>
          <Button
            type="text"
            danger
            icon={<LogoutOutlined />}
            style={buttonStyle}
            onMouseEnter={(e) => e.currentTarget.style.backgroundColor = '#fff1f0'}
            onMouseLeave={(e) => e.currentTarget.style.backgroundColor = 'transparent'}
            onClick={() => {
              logout();
            }}
          >
            Đăng xuất
          </Button>
        </List.Item>
      </List>
    );
  };
  return (
    <div style={{ display: "flex" }}>
      <Popover
        placement="bottomRight"
        title={
          <div style={{ padding: '10px', borderBottom: '1px solid #f0f0f0' }}>
            {authData.fullName ?? "Profile"}
          </div>
        }
        content={content}
        trigger="click"
      >
        <Avatar
          size={38}
          style={{
            backgroundColor: "#ffaa74",
            cursor: 'pointer',
            display: 'flex',
            justifyContent: 'center',
            alignItems: 'center'
          }}
          alt="avatar"
        >
          {authData.fullName.charAt(0).toUpperCase()}
        </Avatar>
      </Popover>
    </div>
  );
};

export default UserProfile;

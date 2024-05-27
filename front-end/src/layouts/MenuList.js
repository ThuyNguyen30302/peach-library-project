import React from "react";
import { HomeOutlined } from "@ant-design/icons";

import { Menu } from "antd";

const MenuList = () => {
  const pageRedirect = (e) => {
    console.log(e);
  };

  const menuItems = [
    { label: "Home",
      key: "home",
      path: "/home",
      icon: <HomeOutlined /> },
    {
      label: "Active",
      key: "active",
      path: "/active",
      icon: <HomeOutlined />,
      children: [
        {
          label: "Active 1",
          key: "active1",
          path: "/active/active1",
          icon: <HomeOutlined />,
        },
      ],
    },
  ];
  return (
    <Menu
      theme="light"
      mode="inline"
      items={menuItems}
      className={"menu-bar"}
      onClick={(e) => pageRedirect(e.key)}
    />
  );
};

export default MenuList;

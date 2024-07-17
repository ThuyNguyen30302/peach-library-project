import React, {useMemo} from 'react';
import { useSelector } from 'react-redux';
import {routeAdminComponents, routeMemberComponents} from "./routes";

export const RouteComponents = () => {
  const authData = useSelector(state => state.root.get('authData'));
  return useMemo(() => {
    if (authData && authData.roles && authData.roles.includes('admin')) {
      return routeAdminComponents;
    } else {
      return routeMemberComponents;
    }
  }, [authData]);
};

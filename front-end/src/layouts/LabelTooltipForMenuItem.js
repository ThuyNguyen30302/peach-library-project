import React from 'react';
import {Tooltip} from "antd";

const LabelTooltipForMenuItem = ({label}) => {
  return (
    <Tooltip title={label} placement="right" style={{}}>
      <div style={{
        overflow: 'hidden',
        textOverflow: 'ellipsis',
        display: '-webkit-box',
        WebkitLineClamp: 1,
        WebkitBoxOrient: 'vertical',
        whiteSpace: 'normal'
      }}>
        <span>{label}</span>
      </div>
    </Tooltip>
  );
};

export default LabelTooltipForMenuItem;
import React, { useState, useEffect } from "react";
import Box from "@mui/material/Box";
import Drawer from "@mui/material/Drawer";
import CssBaseline from "@mui/material/CssBaseline";
import AppBar from "@mui/material/AppBar";
import Toolbar from "@mui/material/Toolbar";
import List from "@mui/material/List";
import Typography from "@mui/material/Typography";
import Divider from "@mui/material/Divider";
import ListItem from "@mui/material/ListItem";
import ListItemButton from "@mui/material/ListItemButton";
import ListItemIcon from "@mui/material/ListItemIcon";
import ListItemText from "@mui/material/ListItemText";
import IconButton from "@mui/material/IconButton";
import MenuIcon from "@mui/icons-material/Menu";
import LogoutIcon from "@mui/icons-material/Logout";
import QueryStatsIcon from "@mui/icons-material/QueryStats";
import TableChartIcon from "@mui/icons-material/TableChart";
import { Link } from "react-router-dom";
import AppRoutes from "../routes";

import { getFinancialInfo } from "../api/api";
import LogoImage from "../assets/food_retailer_logo.png";
import { signOut } from "@aws-amplify/auth";

const drawerWidth = 240;
const signOutCall = () => {
  signOut();
};

function DrawerLeft() {
  const [open, setOpen] = useState(false);
  const [marqueeText, setMarqueeText] = useState("Loading...");

  useEffect(() => {
    const fetchFinancialInfo = async () => {
      try {
        const data = await getFinancialInfo();
        const formattedData = data.map((item) => ({
          name: item.propertyName.replace(/_/g, " "),
          value: item.propertyValue,
        }));

        const marqueeTextContent = formattedData.map((item) => (
          <span key={item.name}>
            <span style={{ color: "white" }}>{item.name}</span> :{" "}
            <span style={{ color: "green" }}>{item.value}</span> |{" "}
          </span>
        ));

        setMarqueeText(marqueeTextContent);
      } catch (error) {
        console.error("Error fetching financial info:", error);
        setMarqueeText("Error loading data");
      }
    };

    fetchFinancialInfo();
  }, []);

  const handleDrawerToggle = () => {
    setOpen(!open);
  };

  const handleItemClick = () => {
    setOpen(false);
  };

  return (
    <Box sx={{ display: "flex" }}>
      <CssBaseline />
      <AppBar
        position="fixed"
        sx={{
          zIndex: (theme) => theme.zIndex.drawer + 1,
          backgroundColor: "#001F3F",
        }}
      >
        <Toolbar>
          <IconButton
            color="inherit"
            aria-label="open drawer"
            edge="start"
            onClick={handleDrawerToggle}
            sx={{ mr: 2, ...(open && { display: "none" }) }}
          >
            <MenuIcon />
          </IconButton>
          <Box className="logo-title-container">
            <img
              src={LogoImage}
              alt="Logo"
              style={{ width: "40px", height: "auto", paddingRight: "8px" }}
            />
            <Typography
              variant="h6"
              noWrap
              component="div"
              sx={{ marginRight: "32px" }}
            >
              Food Retailer Dashboard
            </Typography>
          </Box>
          <Box className="marquee-container">
            <Typography variant="h6" component="span" className="marquee">
              {marqueeText}
            </Typography>
          </Box>
        </Toolbar>
      </AppBar>
      <Drawer
        variant="temporary"
        open={open}
        onClose={handleDrawerToggle}
        sx={{
          "& .MuiDrawer-paper": {
            boxSizing: "border-box",
            width: drawerWidth,
          },
        }}
      >
        <Toolbar />
        <Divider />
        <List>
          {["Consumer History", "Stats"].map((text, index) => (
            <ListItem key={text} disablePadding>
              <ListItemButton
                component={Link}
                to={`/${text === "Consumer History" ? "" : text.toLowerCase()}`}
                onClick={handleItemClick}
              >
                <ListItemIcon>
                  {index % 2 === 0 ? <TableChartIcon /> : <QueryStatsIcon />}
                </ListItemIcon>
                <ListItemText primary={text} />
              </ListItemButton>
            </ListItem>
          ))}
        </List>
        <Divider />
        <List>
          {["Logout"].map((text, index) => (
            <ListItem key={text} disablePadding>
              <ListItemButton
                component={Link}
                to={`/${text.toLowerCase()}`}
                onClick={signOutCall}
              >
                <ListItemIcon>
                  <LogoutIcon />
                </ListItemIcon>
                <ListItemText primary={text} />
              </ListItemButton>
            </ListItem>
          ))}
        </List>
      </Drawer>
      <Box
        component="main"
        sx={{ flexGrow: 1, bgcolor: "background.default", p: 3 }}
      >
        <Toolbar />
        <AppRoutes />
      </Box>
    </Box>
  );
}

export default DrawerLeft;

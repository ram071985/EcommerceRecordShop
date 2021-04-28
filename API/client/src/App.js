import { Route, Switch } from "react-router";
import "./scss/_global.scss";
import Header from "./components/Header/Header";
import Home from "./components/Pages/Home/Home";
import Shop from "./components/Pages/Shop/Shop";
import Product from "./components/Pages/Product/Product";
import Payment from "./components/Pages/Payment/Payment";
import TransactionHistory from "./components/Pages/TransactionHistory/TransactionHistory";
import CIcon from "@coreui/icons-react";

function App() {
  return (
    <div className="App">
      <Header />
      <CIcon size={"sm"} name={"cilSettings"} />
      <h1>HELLO</h1>
      <Switch>
        <Route path="/home" component={Home} />
        <Route path="/shop" component={Shop} />
        <Route path="/product" component={Product} />
        <Route path="/payment" component={Payment} />
        <Route path="/transaction-history" component={TransactionHistory} />
        <Route path="/" component={Home} />
      </Switch>
    </div>
  );
}

export default App;

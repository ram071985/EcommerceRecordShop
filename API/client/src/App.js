import { Route, Switch } from "react-router";
import "./scss/_global.scss";
import Header from "./components/Header/Header";
import Home from "./components/Pages/Home/Home";
import Shop from "./components/Pages/Shop/Shop";
import Product from "./components/Pages/Product/Product";
import Payment from "./components/Pages/Payment/Payment";
import TransactionHistory from "./components/Pages/TransactionHistory/TransactionHistory";

function App() {
  return (
    <div className="App">
      <Header />
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

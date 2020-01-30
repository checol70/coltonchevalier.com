import React from 'react';
import { BrowserRouter, Route, Switch } from 'react-router-dom';
import Container from "./Components/Container";
import Home from "./Pages/Home"
import Desktop from './Pages/Desktop';

function App() {
  return (
    <div>
      <Container>
          <BrowserRouter>
            <div>
              <Switch>
                <Route exact path="/" component={Home} />
                <Route exact path="/desktop" component = {Desktop}/>
                {/*<Route component={noMatch}/>*/}
                
              </Switch>
            </div>
          </BrowserRouter>
        </Container>
    </div>
  );
}

export default App;

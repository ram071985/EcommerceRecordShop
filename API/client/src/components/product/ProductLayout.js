import React, { useState, useEffect } from "react";
import { Container, Row, Col } from "react-bootstrap";

const ProductLayout = () => {
  return (
    <Container fluid>
        <Row>
          <Col className="w-75">How</Col>
          <Col md={4}>How</Col>
        </Row>
   </Container>
  );
};

export default ProductLayout;

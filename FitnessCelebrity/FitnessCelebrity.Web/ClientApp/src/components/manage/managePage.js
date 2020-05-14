import React, { Component } from "react";
import { Link } from "react-router-dom";
import Tabs from "react-bootstrap/Tabs";
import Tab from "react-bootstrap/Tab";
import Accordion from "react-bootstrap/Accordion";
import Card from "react-bootstrap/Card";
import Button from "react-bootstrap/Button";
import EsTable from "../shared/tables/EsTable";
import FitnessPathService from "../../services/FitnessPathService";
import MovementService from "../../services/MovementService";
import WorkoutService from "../../services/WorkoutService";
import AccordionCaret from "../shared/icons/AccordionCaret";

export class ManagePage extends Component {
  static displayName = ManagePage.name;

  render() {
    return (
      <div>
        <h1>Manage Fitness</h1>

        <Tabs defaultActiveKey="created" id="uncontrolled-tab-example">
          <Tab eventKey="created" title="Created">
            <Accordion defaultActiveKey="0">
              <Card>
                <Card.Header>
                  <div className="row">
                    <div className="col-sm-1">
                      <Accordion.Toggle as={Button} variant="link" eventKey="0">
                        <AccordionCaret eventKey="0" />
                      </Accordion.Toggle>
                    </div>
                    <div className="col-sm-5">
                      <h2>Fitness Paths</h2>
                    </div>
                    <div className="col-sm-6">
                      <Link
                        to="/fitnessPath/create"
                        className="btn btn-outline-primary float-right"
                      >
                        Create New Fitness Path
                      </Link>
                    </div>
                  </div>
                </Card.Header>
                <Accordion.Collapse eventKey="0">
                  <Card.Body>
                    <EsTable
                      loadItems={() => FitnessPathService.get()}
                      detailsPath={"fitnessPath"}
                    />
                  </Card.Body>
                </Accordion.Collapse>
              </Card>
              <Card>
                <Card.Header>
                  <div className="row">
                    <div className="col-sm-1">
                      <Accordion.Toggle as={Button} variant="link" eventKey="1">
                        Caret
                      </Accordion.Toggle>
                    </div>
                    <div className="col-sm-5">
                      <h2>Workouts</h2>
                    </div>
                    <div className="col-sm-6">
                      <Link
                        to="/workout/create"
                        className="btn btn-outline-primary float-right"
                      >
                        Create New Workout
                      </Link>
                    </div>
                  </div>
                </Card.Header>
                <Accordion.Collapse eventKey="1">
                  <Card.Body>
                    {" "}
                    <EsTable
                      loadItems={() => WorkoutService.getMyCreatedWorkouts()}
                      detailsPath={"workout"}
                    />
                  </Card.Body>
                </Accordion.Collapse>
              </Card>
              <Card>
                <Card.Header>
                  <div className="row">
                    <div className="col-sm-1">
                      <Accordion.Toggle as={Button} variant="link" eventKey="2">
                        Caret
                      </Accordion.Toggle>
                    </div>
                    <div className="col-sm-5">
                      <h2>Movements</h2>
                    </div>
                    <div className="col-sm-6">
                      <Link
                        to="/movement/create"
                        className="btn btn-outline-primary float-right"
                      >
                        Create New Movement
                      </Link>
                    </div>
                  </div>
                </Card.Header>
                <Accordion.Collapse eventKey="2">
                  <Card.Body>
                    <EsTable
                      loadItems={() => MovementService.getMyCreatedMovements()}
                      detailsPath={"movement"}
                    />
                  </Card.Body>
                </Accordion.Collapse>
              </Card>
            </Accordion>
          </Tab>
          <Tab eventKey="active" title="Active">
            "thing 2"
          </Tab>
          <Tab eventKey="complete" title="Completed">
            "thing 3"
          </Tab>
        </Tabs>
      </div>
    );
  }
}

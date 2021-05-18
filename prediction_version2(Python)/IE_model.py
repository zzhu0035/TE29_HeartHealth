# Import necessary libraries

import pandas as pd
from sklearn.linear_model import LogisticRegression
from flask import Flask, request
from flask_restful import Resource, Api

# Function for implementing the machine learning task

def IE_model(age, sex, cp, trestbps, chol, fbs, rest_ecg, thalach, exang, oldpeak, slope, ca, thal):
    # Importing data from the csv file
    heart_data = pd.read_csv('heart_v2.csv')
    # Getting the required column names
    train_cols_temp = heart_data.columns
    train_cols = train_cols_temp[0:len(train_cols_temp)-1]
    # Defining the model
    model = LogisticRegression(solver = 'liblinear', random_state = 0)
    # Extracting the training dataset from the data
    x_train = heart_data[train_cols]
    y_train = heart_data['output']
    # Fitting the model on the training dataset
    fit_dataset = model.fit(x_train, y_train)
    # Processing the user inputs for passing through the model
    val_list = [[age, sex, cp, trestbps, chol, fbs, rest_ecg, thalach, exang, oldpeak, slope, ca, thal]]
    test_df = pd.DataFrame(val_list, columns = train_cols)
    # Processing the prediction tasks
    final_out = fit_dataset.predict_proba(test_df)[0]
    # Getting the final formatted output
    final_prediction = str(round(final_out[1]*100, 2))
    #final_pred_format = {'Result' : final_prediction}
    return final_prediction


# Flask code to read parameters from url and pass it to the function above.

app = Flask(__name__)
api = Api(app)

@app.route('/recommend/age_value=<age_sel>&sex_value=<sex_sel>&cp_value=<cp_sel>&trestbps_value=<trestbps_sel>&chol_value=<chol_sel>&fbs_value=<fbs_sel>&rest_ecg_value=<rest_ecg_sel>&thalach_value=<thalach_sel>&exang_value=<exang_sel>&oldpeak_value=<oldpeak_sel>&slope_value=<slope_sel>&ca_value=<ca_sel>&thal_value=<thal_sel>')

def model_parse(age_sel, sex_sel, cp_sel, trestbps_sel, chol_sel, fbs_sel, rest_ecg_sel, thalach_sel, exang_sel, oldpeak_sel, slope_sel, ca_sel, thal_sel):
    return {'Result': str(IE_model(age_sel, sex_sel, cp_sel, trestbps_sel, chol_sel, fbs_sel, rest_ecg_sel, thalach_sel, exang_sel, oldpeak_sel, slope_sel, ca_sel, thal_sel))}

if __name__ == '__main__':
    app.run(debug=True)

# Import statements
import pandas as pd
from sklearn.linear_model import LogisticRegression

# Function for implementing the machine learning task

def predict(age, sex, cp, trestbps, chol, fbs, rest_ecg, thalach, exang, oldpeak, slope, ca, thal):
    # Importing data from the csv file
    heart_data = pd.read_csv('heart.csv')
    # Getting the required column names
    train_cols_temp = heart_data.columns
    train_cols = train_cols_temp[0:len(train_cols_temp)-1]
    # Defining the model
    model = LogisticRegression(solver = 'liblinear', random_state = 0)
    # Extracting the training dataset from the data
    x_train = heart_data[train_cols]
    y_train = heart_data['target']
    # Fitting the model on the training dataset
    fit_dataset = model.fit(x_train, y_train)
    # Processing the user inputs for passing through the model
    val_list = [[age, sex, cp, trestbps, chol, fbs, rest_ecg, thalach, exang, oldpeak, slope, ca, thal]]
    test_df = pd.DataFrame(val_list, columns = train_cols)
    # Processing the prediction tasks
    final_out = fit_dataset.predict_proba(test_df)[0]
    # Getting the final formatted output
    final_prediction = str(round(final_out[1]*100, 2))
    final_pred_format = {'Result' : final_prediction}
    return final_pred_format

print(predict(48,1,1,140,290,1,1,140,1,0,0,0,1))
